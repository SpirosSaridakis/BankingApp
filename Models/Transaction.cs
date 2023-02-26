using System;

namespace Padanian_Bank.Models
{
    public enum Type
    {
        Deposit, Withdrawal, TransferFrom, TransferTo
    }

    public class Transaction
    {
        public Type Type {get; set;}

        public float Funds { get; set;}

        public DateTime Timestamp { get; set;}

        public Guid Account_id { get; set;}

        public Transaction()
        {

        }

        public Transaction(Type Atype, float Afunds, DateTime Atimestamp, Guid Aaccount_id)
        {
            Type=Atype;
            Funds=Afunds;
            Timestamp=Atimestamp;
            Account_id=Aaccount_id;
        }
    }
}
