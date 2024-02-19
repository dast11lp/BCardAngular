using FECreditCard.Models;
using Microsoft.EntityFrameworkCore;

namespace FECreditCard
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<CreditCard> CreditCards { get; set; }

        public DbSet<BankAccount> BankAccount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>()
                .Property(b => b.Balance)
                .HasPrecision(20, 5);

            base.OnModelCreating(modelBuilder);
        }
    }
}
