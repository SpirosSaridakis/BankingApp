using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Johns_App.Records;
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

	[HttpPost("/Accounts/Create")]
	public IActionResult create(string Adesc, double Abalance, string Acurrency, int AuserId){
		Account newAcc = new Account(Adesc,Abalance,Acurrency,AuserId);
		bool result = _IpadanianService.create(newAcc);
		//View(result)
		return CreatedAtAction(nameof(create),new{id = newAcc.AccountId},value:MapAccountResponse(newAcc));
	}

	[HttpPost("/Deposit/{AccountId}/Ammount/{ammount}")]
	public IActionResult deposit(Guid id, float ammount){
		bool result = _IpadanianService.deposit(id,ammount);

		return View(result);
	}

	[HttpPost("/Withdraw/{AccountId}/Ammount/{ammount}")]
	public IActionResult withdraw(Guid id, float ammount){
		bool result = _IpadanianService.withdraw(id,ammount);
		return View(result);
	}

	[HttpGet("/Details/{AccountId}")]
	public IActionResult details(Guid id){
		String acc = _IpadanianService.details(id);
		return View(acc);
	}

	public CreateResponseStruct MapAccountResponse(Account acc){
		CreateResponseStruct crs = new CreateResponseStruct(acc);
		return crs;
	}

}
