using System;
using Padanian_Bank.Models;

namespace Johns_App.Records
{
    public struct CreateResponseStruct{
        Guid AccountId;
        string desc;
        string currency;
        double balance;
        int userId;

        public CreateResponseStruct(Account acc){
            AccountId=acc.AccountId;
            desc=acc.Desc;
            currency=acc.Currency;
            balance=acc.Balance;
            userId=acc.UserId;
        }
        
    }
}