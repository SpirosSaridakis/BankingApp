using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Padanian_Bank.Data;
using Padanian_Bank.Models;
using Padanian_Bank.Services.BankService;

namespace Padanian_Bank.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly Ipadanian_Service _IpadanianService;

        public TransactionsController(Ipadanian_Service _PadanianService)
        {
            _IpadanianService = _PadanianService;

        }

        // GET: Transactions
        public IActionResult Index(Guid AccountId)
        {
            List<Transaction> transactions = _IpadanianService.GetAccountTransactions(AccountId);
            return View(transactions);
        }
    }
}
