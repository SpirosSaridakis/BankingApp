using System;
using Padanian_Bank.Services.BankService;
using Padanian_Bank.Models;
using System.Collections.Generic;
using Padanian_Bank.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Principal;

public class Padanian_Service : Ipadanian_Service
{
    //private static readonly Dictionary<Guid,Account> _accounts = new Dictionary<Guid, Account>();
    private readonly ApplicationDbContext _context;
    public Padanian_Service()
	{

	}
    public Account Create(Account account){
        bool flag = true;
        while(flag){
            if(checkIfExists(account.AccountId)==null){
                account.AccountId=Guid.NewGuid();
            }else{
                flag=false;
            }
        }
        _context.Account.Add(account);
        _context.SaveChanges();
        return account;

    }

    public Account Deposit(Guid account_id, float ammount)
    {
        Account data = checkIfExists(account_id);
        if (data == null)
        {
            return null;
        }
        data.Balance += ammount;
        _context.SaveChanges();
        return data; 
        /*
        if(checkIfExists(account_id)==null){
            return false;
        }
        Account acc = _accounts[account_id];
        acc.Balance+=ammount;
        return true;*/
    }

    public Account Details(Guid account_id)
    {
        Account data = checkIfExists(account_id);
        if (data != null) {
            return data;
        }
        else
        {
            return null;
        }
    }

    public Account Withdraw(Guid account_id, float ammount)
    {

        Account data = checkIfExists(account_id);
        if (data==null){
            return null;
        }
        if (data.Balance < ammount)
        {
            return null;
        }
        data.Balance -= ammount;
        _context.SaveChanges();
        return data;
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

    public bool Delete(Guid account_id)
    {
        Account data = checkIfExists(account_id) ;
        if (data != null) 
        {
            _context.Account.Remove(data);
            _context.SaveChanges();
            return true;
        }
        return false;

    }

    public List<Account> Index(String userid)
    {
        List<Account> data = new List<Account>();
        data = _context.Account.Where(x=> x.UserId==userid).ToList();
        if (!(data.Count > 0))
        {
            return null;
        }    
        return data;
    }

    public List<Account> Search(Guid id)
    {
        List<Account> data = new List<Account>();
        data = _context.Account.Where(x => x.AccountId == id).ToList();
        if (!(data.Count > 0))
        {
            return null;
        }
        return data;
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
