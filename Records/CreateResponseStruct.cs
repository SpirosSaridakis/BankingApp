using System;
using Padanian_Bank.Models;

namespace Johns_App.Records
{
    public struct CreateResponseStruct{
        Guid AccountId;
        Desc desc;
        Currency currency;
        double balance;
        String userId;

        public CreateResponseStruct(Account acc){
            AccountId=acc.AccountId;
            desc= (Desc)acc.Desc;
            currency=(Currency)acc.Currency;
            balance=acc.Balance;
            userId=acc.UserId;
        }
        
    }
}
