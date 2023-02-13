using System;
using Padanian_Bank.Models;

namespace Padanian_Bank.Services.BankService{ 
	
	public interface Ipadanian_Service
	{
		bool create(Account account);
		bool deposit(int account_id,float ammount);

		bool withdraw(int account_id, float ammount);

		Account details(Guid account_id);

	}

}