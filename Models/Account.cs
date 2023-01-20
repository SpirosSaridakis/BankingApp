using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padanian_Bank.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string desc { get; set; }
        public double balance { get; set; }
        public string currency { get; set; }
        public int UserId;

        public Account()
            {

            }

    }

    
}
