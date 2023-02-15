using System;
using Padanian_Bank.Models;

namespace Padanian_Bank.Services.BankService{ 
	
	public interface Ipadanian_Service
	{
		bool create(Account account);
		bool deposit(Guid account_id,float ammount);

		bool withdraw(Guid account_id, float ammount);

		string details(Guid account_id);

		Account checkIfExists(Guid account_id);

	}

}