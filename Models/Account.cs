using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padanian_Bank.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public double Balance { get; set; }
        public string Currency { get; set; }
        public int UserId;
        
        
        public Account(/*string Adesc, double Abalance, string Acurrency, int AuserId*/)
            {/*
                AccountId = Guid.NewGuid();
                Desc=Adesc;
                Balance=Abalance;
                Currency=Acurrency;
                UserId=AuserId;
            */
            }

    }
}