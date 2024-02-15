using FECreditCard.Models;
using Microsoft.EntityFrameworkCore;

namespace FECreditCard
{
  public class ApplicationDbContext: DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {

    }

    public DbSet<CreditCard> CreditCards { get; set;}
  }
}
