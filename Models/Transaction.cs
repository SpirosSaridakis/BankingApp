using System;
using System.ComponentModel.DataAnnotations;

namespace Padanian_Bank.Models
{
    public enum TransactionType
    {
        Deposit, Withdrawal, TransferFrom, TransferTo
    }

    public class Transaction
    {
        public TransactionType Type {get; set;}

        public float Funds { get; set;}

        public DateTime Timestamp { get; set;}

        [Key]

        public Guid Account_id { get; set;}

        public Transaction()
        {

        }

        public Transaction(TransactionType Atype, float Afunds, DateTime Atimestamp, Guid Aaccount_id)
        {
            Type=Atype;
            Funds=Afunds;
            Timestamp=Atimestamp;
            Account_id=Aaccount_id;
        }
    }
}
