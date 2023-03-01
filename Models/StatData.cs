using System.Collections.Generic;

namespace Padanian_Bank.Models
{
    public class StatData
    {
        public double TotalMoney;

        public int AccountCount;

        public Dictionary<Desc, int> AccountsPerCategory;

        public int TransactionsToday;
        public StatData() 
        {
        }

        public StatData(double AtotalMoney, int AnAccountCount, Dictionary<Desc, int> AnAccountsPerCategory, int transactionsToday)
        {
            TotalMoney = AtotalMoney;
            AccountCount = AnAccountCount;
            AccountsPerCategory = AnAccountsPerCategory;
            TransactionsToday = transactionsToday;
        }
    }
}
