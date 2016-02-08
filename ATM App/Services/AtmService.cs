using Data.Entities;
using Data.Entities.Enums;
using Data.Repositories;
using System;

namespace ATM_App.Services
{
    public class AtmService : IAtmService
    {
        private IAtmRepository _repository;
        public AtmService(IAtmRepository repository)
        {
            this._repository = repository;
        }

        public int WithdrawMoney(string sessionId, float amount)
        {
            var session = this._repository.GetSession(Guid.Parse(sessionId));

            if (session != null)
            {
                var card = session.Card;

                card.Balance -= amount;

                if (card.Balance >= 0)
                {
                    this._repository.UpdateCard(card);
                    return this._repository.CreateOperation(OperationType.Withdraw, session.ID, card.Balance + amount);
                }
                else
                {
                    throw new Exception("There is not enough funds");
                }
            }
            else
            {
                throw new ArgumentException("Invalid session");
            }

        }

        public float GetBalance(string sessionId)
        {
            var session = this._repository.GetSession(Guid.Parse(sessionId));

            if (session != null)
            {
                return session.Card.Balance;
            }

            throw new Exception("Invalid session");
        }

        public bool ValidatePin(string cardNumber, string pinCode)
        {
            var card = this._repository.GetCard(cardNumber);

            if (card != null)
            {
                if (card.PinHash == PinHasher.Encode(pinCode))
                {
                    card.IncorectPins = 0;

                    this._repository.UpdateCard(card);
                    return true;
                }

                card.IncorectPins++;
                this._repository.UpdateCard(card);

                if (card.IncorectPins >= 4)
                {
                    card.IsBlocked = true;
                    this._repository.UpdateCard(card);

                    throw new Exception("Incorrect pin has been entered 4 times in a row. Card has been blocked.");
                }
            }

            return false;
        }

        public Card GetCardInfo(string cardNumber)
        {
            return this._repository.GetCard(cardNumber);
        }

        public string CreateSession(string cardNumber)
        {
            this._repository.InvalidateSessions(cardNumber);
            return this._repository.CreateSession(cardNumber);
        }

        public void LogOut(string sessionId)
        {
            this._repository.InvalidateSession(Guid.Parse(sessionId));
        }

        public Operation GetOperation(int operationId)
        {
            return this._repository.GetOperation(operationId);
        }
    }
}