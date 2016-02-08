using ATM_App.Models;
using ATM_App.Services;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ATM_App.Controllers
{
    public class AtmController : ApiController
    {
        private IAtmService _service;
        public AtmController(IAtmService service)
        {
            _service = service;
        }

        [HttpGet]
        public HttpResponseMessage ValidateCardNumber(string cardNumber)
        {
            var card = this._service.GetCardInfo(cardNumber);

            return this.Request.CreateResponse(
                HttpStatusCode.OK,
                new { isValid = card != null && !card.IsBlocked });
        }

        [HttpPost]
        public HttpResponseMessage ValidatePin([FromBody]PinModel formData, string cardNumber)
        {
            var isPinValid = false;

            try
            {
                isPinValid = this._service.ValidatePin(cardNumber, formData.pinCode);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(
                HttpStatusCode.BadRequest,
                new { message = ex.Message });
            }

            if (isPinValid)
            {
                return this.Request.CreateResponse(
                HttpStatusCode.OK,
                new { sessionId = this._service.CreateSession(cardNumber) });
            }

            return this.Request.CreateResponse(
                HttpStatusCode.Unauthorized,
                new { message = "Invalid card number or pin code" });
        }

        public HttpResponseMessage GetBalance(string sessionId)
        {
            float balance = 0;

            try
            {
                balance = this._service.GetBalance(sessionId);
            }
            catch (ArgumentException exception)
            {
                return this.Request.CreateResponse(
                HttpStatusCode.BadRequest,
                new { message = exception.Message });
            }
            catch (Exception exception)
            {
                return this.Request.CreateResponse(
                HttpStatusCode.InternalServerError,
                new { message = "Unexpected error occured" });
            }

            return this.Request.CreateResponse(
                HttpStatusCode.OK,
                new { balance = balance });
        }

        [HttpPost]
        public HttpResponseMessage WithdrawMoney(string sessionId, [FromBody]CardBalanceModel model)
        {
            try
            {
                var operationId = this._service.WithdrawMoney(sessionId, model.withdrawAmount);

                return this.Request.CreateResponse(
                HttpStatusCode.OK,
                new { operationId = operationId});
            }
            catch (ArgumentException exception)
            {
                return this.Request.CreateResponse(
                HttpStatusCode.BadRequest,
                new { message = exception.Message });
            }
            catch (Exception exception)
            {
                return this.Request.CreateResponse(
                HttpStatusCode.InternalServerError,
                new { message = "Unexpected error occured" });
            }
        }

        [HttpPost]
        public HttpResponseMessage LogOut(string sessionId)
        {
            this._service.LogOut(sessionId);

            return this.Request.CreateResponse(
                HttpStatusCode.NoContent);
        }

        public HttpResponseMessage GetOperation(int operationId)
        {
            var operation = this._service.GetOperation(operationId);

            if(operation != null)
            {
                var card = operation.Session.Card;
                return this.Request.CreateResponse(
               HttpStatusCode.OK,
               new { cardNumber = card.CardNumber, balance = card.Balance, balanceBefore = operation.BalanceBefore, date = operation.Date.Date});
            }

            return this.Request.CreateResponse(
                HttpStatusCode.NotFound,
                new { message = "Operation not found"});
        }
    }
}
