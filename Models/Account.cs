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
<<<<<<< Updated upstream
        public string Currency { get; set; }
        public int UserId;
=======
        [DisplayFormat(NullDisplayText = "No Currency")]
        public Currency? Currency { get; set; }
        public String? UserId;
>>>>>>> Stashed changes
        
        public Account(){
            
        }
        
<<<<<<< Updated upstream
        public Account(/*string Adesc, double Abalance, string Acurrency, int AuserId*/)
            {/*
=======
        public Account(Desc Adesc, double Abalance, Currency Acurrency, String? AuserId)
            {
>>>>>>> Stashed changes
                AccountId = Guid.NewGuid();
                Desc=Adesc;
                Balance=Abalance;
                Currency=Acurrency;
                UserId=AuserId;
            */
            }

    }
}