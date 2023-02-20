using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Padanian_Bank.Models
{
    public enum Currency
    {
        Euro, Dollar, British_Pound
    }

    public enum Desc
    {
        Salary, Investor, Savings, Business
    }

    public class Account
    {

        public Guid AccountId { get; set; }
        [DisplayFormat(NullDisplayText = "No Description")]
        public Desc? Desc { get; set; }
        [DisplayFormat(NullDisplayText = "Zero Balance")]
        public double Balance { get; set; }
        [DisplayFormat(NullDisplayText = "No Currency")]
        public Currency? Currency { get; set; }
        public String? UserId;

        
        public Account(){
            
        }
        
        public Account(Desc Adesc, double Abalance, Currency Acurrency, String? AuserId){
                AccountId = Guid.NewGuid();
                Desc=Adesc;
                Balance=Abalance;
                Currency=Acurrency;
                UserId=AuserId;
        }


}