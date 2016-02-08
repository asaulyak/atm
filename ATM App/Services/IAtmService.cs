using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM_App.Services
{
    public interface IAtmService
    {
        int WithdrawMoney(string sessionId, float amount);
        float GetBalance(string sessionId);
        bool ValidatePin(string cardNumber, string pinCode);
        Card GetCardInfo(string cardNumber);
        string CreateSession(string cardNumber);
        void LogOut(string sessionId);
        Operation GetOperation(int operationId);           
    }
}