using System;
using Padanian_Bank.Services.BankService;
using Padanian_Bank.Models;
using System.Collections.Generic;

public class Padanian_Service : Ipadanian_Service
{
    private static readonly Dictionary<Guid,Account> _accounts = new Dictionary<Guid, Account>();
	public Padanian_Service()
	{

	}
    public bool create(Account account){
        if((details(account.AccountId))!=null){
            _accounts.Add(account.AccountId,account);
            return true;
        }else{
            return false;
        }

    }

    public bool deposit(int account_id, float ammount)
    {
        throw new NotImplementedException();
    }

    public Account details(Guid account_id)
    {
         if(_accounts.TryGetValue(account_id,out var acc)){
            return acc;
        }else{
            return null;
        }
    }

    public bool withdraw(int account_id, float ammount)
    {
        throw new NotImplementedException();
    }

    
}
