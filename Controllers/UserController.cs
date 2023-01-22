using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Padanian_Bank.Data;
using Padanian_Bank.Models;

public class UserController : Controller
{
	public UserController()
	{
	}
	[HttpPost]
	public IActionResult Deposit(){

		return Ok();
	}

	[HttpPost]
	public IActionResult Withdraw(){
	
		return Ok();
	}

	[HttpGet]
	public IActionResult Details(){

		return Ok();
	}



}
