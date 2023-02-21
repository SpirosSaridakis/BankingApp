using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Padanian_Bank.Models;
using System.Collections.Generic;

namespace Padanian_Bank.Services.BankService{ 
	
	public interface Ipadanian_Service
	{

		Account create(Account account);
        Account deposit(Guid account_id, float ammount);

		Account withdraw(Guid account_id, float ammount);

		Account details(Guid account_id);

		Account checkIfExists(Guid account_id);
		
		bool delete(Guid account_id);

		List<Account> index(int userid);

		List<Account> search(Guid account_id);

	}

}