using Microsoft.EntityFrameworkCore;

namespace CarDealer.Models
{
  public class CarDealerContext : DbContext
  {
    public DbSet<Car> Cars { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<PendingSales> Pending_Sales { get; set; }

    public CarDealerContext(DbContextOptions options) : base(options) { }
  }
}