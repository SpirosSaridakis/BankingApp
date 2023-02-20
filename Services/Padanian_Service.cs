using System;
using Padanian_Bank.Services.BankService;
using Padanian_Bank.Models;
using System.Collections.Generic;
using Padanian_Bank.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class Padanian_Service : Ipadanian_Service
{
    //private static readonly Dictionary<Guid,Account> _accounts = new Dictionary<Guid, Account>();
    private readonly ApplicationDbContext _context;
    public Padanian_Service()
	{

	}
    public bool create(Account account){
        _context.Account.Add(account);
        _context.SaveChanges();
        return true;
        
        /*bool flag = true;
        while(flag){
            if(checkIfExists(account.AccountId)==null){
                account.AccountId=Guid.NewGuid();
            }else{
                flag=false;
            }
        }
        _accounts.Add(account.AccountId,account);
        return true;*/

    }

    public bool deposit(Guid account_id, float ammount)
    {
        Account data = checkIfExists(account_id);
        if (data != null)
        {
            data.Balance += ammount;
            _context.SaveChanges();
            return true;
        }
        else
        {
            return false; 
        }
        
        /*
        if(checkIfExists(account_id)==null){
            return false;
        }
        Account acc = _accounts[account_id];
        acc.Balance+=ammount;
        return true;*/
    }

    public Account details(Guid account_id)
    {
        Account data = checkIfExists(account_id);
        if (data != null) {
            return data;
        }
        else
        {
            return null;
        }

        /*
         if(_accounts.TryGetValue(account_id,out var acc)){
            acc = _accounts[account_id];
            string details = "Description: "+acc.Desc+"\nBalance: "+acc.Balance+"\nCurrency: "+acc.Currency;
            return details;
        }else{
            return "Account does not exist";
        }*/
    }

    public bool withdraw(Guid account_id, float ammount)
    {

        Account data = checkIfExists(account_id);
        if (data==null){
            return false;
        }
        if (data.Balance < ammount)
        {
            return false;
        }
        data.Balance -= ammount;
        _context.SaveChanges();
        return true;
        /*
        if(checkIfExists(account_id)==null){
            return false;
        }else if(_accounts[account_id].Balance<ammount){
            return false;
        }
        _accounts[account_id].Balance-=ammount;
        //log transaction
        return true;
        */
    }

    public Account checkIfExists(Guid account_id){

        Account data = (Account)_context.Account.Where(x => x.AccountId == account_id);
        if (data != null)
        {
            return data;
        }
        else
        {
            return null;
        }
    }

    
}
