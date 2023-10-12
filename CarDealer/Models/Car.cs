namespace CarDealer.Models
{
  public class Car
  {
    public int CarId { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public int ModelYear { get; set; }

    public int Mileage { get; set; }

    public string Color { get; set; }

    public List<PendingSales> JoinEntities { get; }  // collection navigation property.
  }
}