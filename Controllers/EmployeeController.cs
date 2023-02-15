using System;
using Padanian_Bank.Services.BankService;

public class EmployeeController : UserController
{
	public EmployeeController(Ipadanian_Service _PadanianService):base(_PadanianService)
	{
	}
}
