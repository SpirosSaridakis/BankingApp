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
	public IActionResult deposit(Guid id, float ammount){
		bool result = _IpadanianService.deposit(id,ammount);

		return View(result);
	}

	[HttpPost("path")]
	public IActionResult withdraw(Guid id, float ammount){
		bool result = _IpadanianService.withdraw(id,ammount);
		return View(result);
	}

	[HttpGet("path")]
	public IActionResult details(Guid id){
		String acc = _IpadanianService.details(id);
		return View(acc);
	}

}
