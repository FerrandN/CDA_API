using cereales.Models;
using Microsoft.EntityFrameworkCore;

namespace cereales.Db
{
    public class CerealDbContext : DbContext
    {
        public DbSet<Cereal> Cereals {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=db_cereals");
        }
    }
}
