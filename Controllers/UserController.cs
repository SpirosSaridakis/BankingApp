using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Padanian_Bank.Data;
using Padanian_Bank.Models;
using Padanian_Bank.Services.BankService;
public class UserController : Controller
{
	private readonly Ipadanian_Service _IpadanianService;
	public UserController(Ipadanian_Service _PadanianService)
	{
		_IpadanianService = _PadanianService;
	}
	[HttpPost("path")]
	public IActionResult deposit(int id, float ammount){
		bool result = _IpadanianService.deposit(id,ammount);

		return Ok();
	}

	[HttpPost("path")]
	public IActionResult withdraw(int id, float ammount){
		bool result = _IpadanianService.withdraw(id,ammount);
		return Ok();
	}

	[HttpGet("path")]
	public IActionResult details(Guid id){
		Account acc = _IpadanianService.details(id);
		return Ok();
	}



}
