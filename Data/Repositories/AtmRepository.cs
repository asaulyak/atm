using Data.Entities;
using Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AtmRepository : IAtmRepository
    {
        private readonly IAtmContext _context;
        public AtmRepository(IAtmContext context)
        {
            this._context = context;
        }

        public Card GetCard(string cardNumber)
        {
            return this._context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
        }

        public void UpdateCard(Card card)
        {
            var storedCard = this._context.Cards.FirstOrDefault(x => x.ID == card.ID);

            if(storedCard != null)
            {
                storedCard.Balance = card.Balance;
            }

            this._context.Entry(card).State = System.Data.Entity.EntityState.Modified;
            this._context.SaveChanges();
        }

        public int CreateOperation(OperationType type, int sessionId, float balanceBefore)
        {
            var session = this._context.Sessions.FirstOrDefault(x => x.ID == sessionId);

            var operation = new Operation
            {
                Date = DateTime.Now,
                Type = type,
                Session = session,
                BalanceBefore = balanceBefore
            };

            this._context.Operations.Add(operation);

            this._context.SaveChanges();

            return operation.ID;
        }

        public Operation GetOperation(int id)
        {
            return this._context.Operations.FirstOrDefault(x => x.ID == id);
        }

        public Session GetSession(Guid sessionId)
        {
            return this._context.Sessions.FirstOrDefault(x => x.SessionId == sessionId && x.IsActive && x.Expires > DateTime.Now);
        }

        public string CreateSession(string cardNumber)
        {
            var card = this._context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber && !x.IsBlocked);

            if(card == null)
            {
                return null;
            }

            var maxId = this._context.Sessions
                .Select(x => x.ID)
                .DefaultIfEmpty(0)
                .Max();

            var session = new Session()
            {
                Card = card,
                IsActive = true,
                ID = ++maxId,
                SessionId = Guid.NewGuid(),
                Expires = DateTime.Now + TimeSpan.FromMinutes(30)
            };

            this._context.Sessions.Add(session);

            this._context.SaveChanges();

            return session.SessionId.ToString();
        }

        public void InvalidateSessions (string cardNumber)
        {
            this._context.Sessions
                .Where(x => x.Card.CardNumber == cardNumber)
                .ToList()
                .ForEach(x => x.IsActive = false);

            this._context.SaveChanges();             
        }

        public void InvalidateSession(Guid sessionId)
        {
            var session = this._context.Sessions.FirstOrDefault(x => x.SessionId == sessionId);

            if(session != null)
            {
                session.IsActive = false;
            }
            
            this._context.SaveChanges();
        }
    }
}