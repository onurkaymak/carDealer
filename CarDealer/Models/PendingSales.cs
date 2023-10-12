namespace CarDealer.Models
{
  public class PendingSales
  {
    public int SalesId { get; set; }
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public Car Car { get; set; } // reference navigation property
    public Customer Customer { get; set; } // reference navigation property
  }
}