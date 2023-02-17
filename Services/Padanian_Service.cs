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
        bool flag = true;
        while(flag){
            if(checkIfExists(account.AccountId)==null){
                account.AccountId=Guid.NewGuid();
            }else{
                flag=false;
            }
        }
        _accounts.Add(account.AccountId,account);
        return true;

    }

    public bool deposit(Guid account_id, float ammount)
    {
        if(checkIfExists(account_id)==null){
            return false;
        }
        Account acc = _accounts[account_id];
        acc.Balance+=ammount;
        return true;
    }

    public string details(Guid account_id)
    {
         if(_accounts.TryGetValue(account_id,out var acc)){
            acc = _accounts[account_id];
            string details = "Description: "+acc.Desc+"\nBalance: "+acc.Balance+"\nCurrency: "+acc.Currency;
            return details;
        }else{
            return "Account does not exist";
        }
    }

    public bool withdraw(Guid account_id, float ammount)
    {
        
        if(checkIfExists(account_id)==null){
            return false;
        }else if(_accounts[account_id].Balance<ammount){
            return false;
        }
        _accounts[account_id].Balance-=ammount;
        //log transaction
        return true;

    }

    public Account checkIfExists(Guid account_id){

        if(_accounts.TryGetValue(account_id,out var acc)){
            return acc;
        }else{
            return null;
        }
    }

    
}
