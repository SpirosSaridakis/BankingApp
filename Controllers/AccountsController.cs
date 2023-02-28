
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Padanian_Bank.Models;
using Padanian_Bank.Services.BankService;
using System.Security.Claims;

namespace Padanian_Bank.Controllers
{
    public class AccountsController : Controller
    {
        private readonly Ipadanian_Service _IpadanianService;
        public String Id { get; set; }


        public AccountsController(Ipadanian_Service _PadanianService)
        {
            _IpadanianService = _PadanianService;

        }


        // GET: Accounts
        [Authorize]
        public IActionResult Index()
        {
            if (User.IsInRole("Customer"))
            {
                Id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                List<Account> list = _IpadanianService.Index(Id);
                return View(list);
            }else if (User.IsInRole("Employee"))
            {
                List<Account> list = _IpadanianService.Index();
                return View(list);
            }
            return NotFound();
            
        }

        // GET: Accounts/ShowSearchForm
        [Authorize(Roles = "Employee")]
        public IActionResult ShowSearchForm()
        {
            return View();
        }

        // POST: Accounts/ShowSearchResults
        [Authorize(Roles = "Employee")]
        [Authorize(Roles = "Employee")]
        [HttpPost]
        public IActionResult ShowSearchResults(Guid SearchPhrase)
        {
            List<Account> list = _IpadanianService.Search(SearchPhrase);
            if (list == null)
            {
                return NotFound();
            }
            return View("Index", list);
        }

        // GET: Accounts/Deposit/5
        [Authorize]
        public IActionResult Deposit(Guid id)
        {
            
            if (id == null)
            {
                return NullCheck(null);
            }
            var account = _IpadanianService.Details(id);
            return (NullCheck(account));
        }

        // POST: Accounts/Deposit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(Guid id, float Funds)
        {
            Account acc = _IpadanianService.Deposit(id, Funds);
            return RedirectCheck(acc);

        }

        // GET: Accounts/Withdraw/5
        [Authorize]
        public IActionResult Withdraw(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = _IpadanianService.Details(id);
            return (NullCheck(account));
        }

        // POST: Accounts/Withdraw/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Withdraw(Guid id, float Funds)
        {
            Account acc = _IpadanianService.Withdraw(id, Funds);
            return RedirectCheck(acc);
        }

        // GET: Accounts/Transfer/5
        [Authorize]
        public IActionResult Transfer(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = _IpadanianService.Details(id);
            return (NullCheck(account));
        }
        

        // POST: Accounts/Transfer/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Transfer(Guid AccId, float Funds, Account account)
        {
            Account recvAcc = _IpadanianService.Transfer(AccId, account.AccountId, Funds);
            return NullCheck(recvAcc);
            
        }
        // GET: Accounts/Details/5
        [Authorize]
        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var account = _IpadanianService.Details(id);
            return (NullCheck(account));
        }

        // GET: Accounts/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AccountId,Desc,Balance,Currency")] Account account)
        {
            account.UserId= User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Account data = _IpadanianService.Create(account);
            return RedirectCheck(data);

        }

        // GET: Accounts/Edit/5
        [Authorize]
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Account acc = _IpadanianService.Details(id);
            return(NullCheck(acc));

           
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = "Employee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid AccountId, Desc Desc)
        {
            Account data = _IpadanianService.Edit(AccountId, Desc);
            return (RedirectCheck(data));
        }
        

        // GET: Accounts/Delete/5
        [Authorize]
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account acc = _IpadanianService.Details(id);
            return (NullCheck(acc));
        }

        // POST: Accounts/Delete/5
        [Authorize(Roles = "Employee")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(Guid id)
        {
            bool result = _IpadanianService.Delete(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        //GET:Accounts/AccountHistory
        [Authorize]
        [HttpGet]
        public IActionResult AccountHistory(Guid account_id)
        {
            List<Transaction> transactions = _IpadanianService.GetAccountTransactions(account_id);
            if(transactions.Count == 0)
            {
                return NotFound();
            }
            return View(transactions);
        }

        
        public IActionResult NullCheck(Account acc)
        {
            if (acc == null)
            {
                return View("NullCheck");
            }
            return View(acc);
        }

        public IActionResult RedirectCheck(Account acc)
        {
            if (acc == null)
            {
                return View("RedirectCheck");
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
