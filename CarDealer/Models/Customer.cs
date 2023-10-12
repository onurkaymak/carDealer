using System.Collections.Generic;


namespace CarDealer.Models
{
  public class Customer
  {
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public int PhoneNumber { get; set; }
    public List<PendingSales> JoinEntities { get; }  // collection navigation property.
  }
}