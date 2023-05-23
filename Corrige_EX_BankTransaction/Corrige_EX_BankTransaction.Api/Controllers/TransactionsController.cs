using BankTransactions.Database;
using BankTransactions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Corrige_EX_BankTransaction.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly BankDbContext context;
        public TransactionsController()
        {
            context = new();
        }

        [HttpGet]
        public ActionResult<IEnumerable<BankTransaction>> GetAll()
        {
            if(context.Transactions == null)
            {
                return NoContent();
            }

            return context.Transactions.ToList();
        }

        [HttpPost]
        public async Task<ActionResult<BankTransaction>> Post(BankTransaction transaction)
        {
            //context.Transactions.Add(transaction);
            if(transaction.Transaction_From == transaction.Transaction_To)
            {
                return BadRequest("Les comptes doivent être différents !");
            }

            EntityEntry<BankTransaction> item = context.Add(transaction);

            BankTransaction newItem = item.Entity;

            await context.SaveChangesAsync();

            return newItem;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            BankTransaction? dbItem = await context.Transactions.FirstOrDefaultAsync(t => t.Transaction_Id == id);

            if(dbItem is BankTransaction && dbItem != null)
            {
                context.Remove(dbItem);
                await context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BankTransaction>> Get(int id)
        {
            BankTransaction? dbItem = await context.Transactions.FirstOrDefaultAsync(t => t.Transaction_Id == id);

            if (dbItem is BankTransaction && dbItem != null)
            {
                return dbItem;
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BankTransaction>> Put(int id, BankTransaction transaction)
        {
            return NotFound("La mise à jour d'une transaction est impossible");
                /*
            if(id != transaction.Transaction_Id)
            {
                return BadRequest();
            }

            context.Entry(transaction).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return NoContent();
                */
        }
        /*
        [HttpPut("{id}")]
        public async Task<ActionResult<BankTransaction>> Put(int id, BankTransaction transaction)
        {
            if (id != transaction.Transaction_Id)
            {
                return BadRequest();
            }

            BankTransaction? dbItem = await context.Transactions.FirstOrDefault(t => t.Transaction_Id == id);

            if(dbItem is null)
            {
                return NotFound();
            }

            dbItem.UpdateFromAnotherTransactionInstance(transaction);

            await context.SaveChangesAsync();

            return NoContent();
        }*/
    }
}
