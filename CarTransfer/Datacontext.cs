using CarTransfer.Models;
using Microsoft.EntityFrameworkCore;

namespace CarTransfer
{
    public class Datacontext : DbContext
    {
        public DbSet<Car> cars { get; set; }
        public DbSet<Transfers> transfers { get; set; }
        public DbSet<User> users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TransferDb;Integrated Security=True;Encrypt=False");
        }
    }
}
