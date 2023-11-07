using Domain.ValueObjects;

namespace Domain.Entities;

public class Place
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    
    public int TypeOfPlaceId { get; set; }
    public PlaceType TypeOfPlace { get; set; }
    
    
    public int PlaceLocationId { get; set; }
    public Location PlaceLocation { get; set; }
}