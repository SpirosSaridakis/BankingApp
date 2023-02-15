using System;
using Padanian_Bank.Services.BankService;
using Padanian_Bank.Models;
using System.Collections.Generic;

public class Padanian_Service : Ipadanian_Service
{
    private static readonly Dictionary<int,Account> _accounts = new Dictionary<int, Account>();
	public Padanian_Service()
	{

	}
    public bool create(Account account){
        if(checkIfExists(account.Id)==null){
            return false;
        }
        _accounts.Add(account.Id,account);
        return true;

    }

    public bool deposit(int account_id, float ammount)
    {
        if(checkIfExists(account_id)==null){
            return false;
        }
        Account acc = _accounts[account_id];
        acc.Balance+=ammount;
        return true;
    }

    public string details(int account_id)
    {
         if(_accounts.TryGetValue(account_id,out var acc)){
            acc = _accounts[account_id];
            string details = "Description: "+acc.Desc+"\nBalance: "+acc.Balance+"\nCurrency: "+acc.Currency;
            return details;
        }else{
            return "Account does not exist";
        }
    }

    public bool withdraw(int account_id, float ammount)
    {
        
        if(checkIfExists(account_id)==null){
            return false;
        }else if(_accounts[account_id].Balance<ammount){
            return false;
        }
        _accounts[account_id].Balance-=ammount;
        return true;

    }

    public Account checkIfExists(int account_id){

        if(_accounts.TryGetValue(account_id,out var acc)){
            return acc;
        }else{
            return null;
        }
    }

    
}
