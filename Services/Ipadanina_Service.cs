using System;
using Padanian_Bank.Models;

namespace Ipadanian_Service { 
	
	public interface _Ipadanian_Service
	{
		bool deposit(int account_id,int ammount);

		bool withdraw(int account_id, int ammount);

		Account details(int account_id);

	}

}