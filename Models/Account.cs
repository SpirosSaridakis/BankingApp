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

        public Account()
            {

            }

        public double Deposit(double amount)
        {

            return Balance + amount;

        }

        public double Deposit(int amount)
        {

            if( amount > Balance)
            {
                return 1;
            }
            return Balance - amount;

        }

    }

    
}
