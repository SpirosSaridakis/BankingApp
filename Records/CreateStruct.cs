using Padanian_Bank.Models;
namespace Johns_App.Records
{
    public struct CreateAccountRequest{
        public Desc desc;
        public Currency currency;
        public double balance;
        public int userid;
    }
}