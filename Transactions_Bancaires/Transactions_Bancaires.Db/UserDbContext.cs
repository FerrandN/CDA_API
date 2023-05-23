using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions_Bancaires.Models;

namespace Transactions_Bancaires.Db
{
    public class UserDbContext : DbContext
    {
        public DbSet<BankTransaction> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=tp_banks");
        }
    }
}
