
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Johns_App.Records;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Padanian_Bank.Data;
using Padanian_Bank.Models;
using Padanian_Bank.Services.BankService;

namespace Padanian_Bank.Controllers
{
    public class AccountsController : Controller
    {
        private readonly Ipadanian_Service _IpadanianService;

        public AccountsController(Ipadanian_Service _PadanianService)
        {
            _IpadanianService = _PadanianService;
        }

        // GET: Accounts
        [Authorize]
        public IActionResult Index(String userid)
        {
            List<Account> list = _IpadanianService.Index(userid);
            if (list==null)
            {
                return NotFound();
            }
            return View(list);
            //return View(await _context.Account.ToListAsync());
        }

        // GET: Accounts/ShowSearchForm
        [Authorize]
        public IActionResult ShowSearchForm()
        {
            return View();
        }

        // POST: Accounts/ShowSearchResults
        [Authorize]
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
                return NotFound();
            }
            var account = _IpadanianService.Details(id);
            return (NullCheck(account));
            /*
            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);*/
        }

        // POST: Accounts/Deposit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Deposit(Guid id, float Funds/*, [Bind("AccountId,Desc,Balance,Currency")] Account account*/)
        {
            Account acc = _IpadanianService.Deposit(id, Funds);
            if (acc == null)
            {
                return NotFound();
            }
            return View(acc);

            /*
            if (id != account.AccountId)
            {
                return NotFound();
            }

            account.Balance += Funds;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }*/
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
            if (acc == null)
            {
                return NotFound();
            }    
            return View(acc);
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
        /*

        // POST: Accounts/Transfer/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Transfer(Guid id, Guid AccId, float Funds, [Bind("AccountId,Desc,Balance,Currency")] Account account)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }

            if ((account.Balance - Funds) >= 0)
            {
                account.Balance = account.Balance - Funds;

                Account acc = new Account();
                acc.AccountId = AccId;
                acc.Balance = acc.Balance + Funds;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }
        */
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
        public IActionResult Create(/*[Bind("AccountId,Desc,Balance,Currency")] Account account*/ CreateAccountRequest crs)
        {
            Account account = new Account(crs.desc, crs.balance, crs.currency, crs.userid);
            var data = _IpadanianService.Create(account);
            return (NullCheck(data));
            
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

            /*
            

            var account = await _context.Account.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
            */
        }
        /*
        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("AccountId,Desc,Balance,Currency")] Account account)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(account);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }
        */
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
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //Here is the method that actually deletes the account
        public IActionResult DeleteConfirmed(Guid id)
        {
            bool result = _IpadanianService.Delete(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        public IActionResult NullCheck(Account acc)
        {
            if (acc == null)
            {
                return NotFound();
            }
            return View(acc);
        }
    }
}
