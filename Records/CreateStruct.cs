using Padanian_Bank.Models;
using System;

namespace Johns_App.Records
{
    public struct CreateAccountRequest{
        public Desc desc;
        public Currency currency;
        public double balance;
        public String userid;
    }
}
