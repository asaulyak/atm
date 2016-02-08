using Data.Entities;
using Data.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IAtmRepository
    {
        Card GetCard(string cardNumber);
        void UpdateCard(Card card);
        //Card ValidateSession(Guid sessionId);
        int CreateOperation(OperationType type, int sessionId, float balanceBefore);
        Operation GetOperation(int id);
        Session GetSession(Guid sessionId);
        string CreateSession(string cardNumber);
        void InvalidateSessions(string cardNumber);
        void InvalidateSession(Guid sessionId);
    }
}
