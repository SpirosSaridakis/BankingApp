﻿using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Padanian_Bank.Models;
using System.Collections.Generic;
using Padanian_Bank.Data;

namespace Padanian_Bank.Services.BankService{ 
	
	public interface Ipadanian_Service
	{

		Account Create(Account account);
        Account Deposit(Guid account_id, float ammount);

		Account Withdraw(Guid account_id, float ammount);

		Account Details(Guid account_id);

		Account checkIfExists(Guid account_id);
		
		bool Delete(Guid account_id);

		Account Transfer(Guid recvId, Guid sendId,float ammount);

		List<Account> Index(/*int userid*/);

		List<Account> Search(Guid account_id);

	}

}