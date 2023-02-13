using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padanian_Bank.Models
{
    public class Account
    {
        public Guid AccountId { get; set; }
        public string desc { get; set; }
        public double balance { get; set; }
        public string currency { get; set; }
        public int UserId;

        public Account(string Adesc, double Abalance, string Acurrency, int AuserId)
            {
                AccountId = Guid.NewGuid();
                desc=Adesc;
                balance=Abalance;
                currency=Acurrency;
                UserId=AuserId;

            }

    }

    
}
