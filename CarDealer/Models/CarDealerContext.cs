using Microsoft.EntityFrameworkCore;

namespace CarDealer.Models
{
  public class CarDealerContext : DbContext
  {
    public DbSet<Car> Cars { get; set; }

    public CarDealerContext(DbContextOptions options) : base(options) { }
  }
}