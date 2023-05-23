using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankTransactions.Database;
using BankTransactions.Models;

namespace BankTransactions.WebApp.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly BankDbContext _context;

        public TransactionsController()
        {
            _context = new();
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
              return _context.Transactions != null ? 
                          View(await _context.Transactions.ToListAsync()) :
                          Problem("Entity set 'BankDbContext.Transactions'  is null.");
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var bankTransaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.Transaction_Id == id);
            if (bankTransaction == null)
            {
                return NotFound();
            }

            return View(bankTransaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Transaction_Id,Transaction_Date,Transaction_From,Transaction_To,Transaction_Amount")] BankTransaction bankTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bankTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bankTransaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var bankTransaction = await _context.Transactions.FindAsync(id);
            if (bankTransaction == null)
            {
                return NotFound();
            }
            return View(bankTransaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Transaction_Id,Transaction_Date,Transaction_From,Transaction_To,Transaction_Amount")] BankTransaction bankTransaction)
        {
            if (id != bankTransaction.Transaction_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankTransactionExists(bankTransaction.Transaction_Id))
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
            return View(bankTransaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transactions == null)
            {
                return NotFound();
            }

            var bankTransaction = await _context.Transactions
                .FirstOrDefaultAsync(m => m.Transaction_Id == id);
            if (bankTransaction == null)
            {
                return NotFound();
            }

            return View(bankTransaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transactions == null)
            {
                return Problem("Entity set 'BankDbContext.Transactions'  is null.");
            }
            var bankTransaction = await _context.Transactions.FindAsync(id);
            if (bankTransaction != null)
            {
                _context.Transactions.Remove(bankTransaction);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankTransactionExists(int id)
        {
          return (_context.Transactions?.Any(e => e.Transaction_Id == id)).GetValueOrDefault();
        }
    }
}
