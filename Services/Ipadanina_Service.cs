using System;
namespace Ipadanian_Service { 
	
	public interface Ipadanian_Service
	{
		bool deposit(int account_id,int ammount);

		bool withdraw(int account_id, int ammount);

		Account details(int account_id);

	}

}