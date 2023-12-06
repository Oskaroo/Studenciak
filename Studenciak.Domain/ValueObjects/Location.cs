using Domain.Entities;

namespace Domain.ValueObjects;

public class Location
{
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public string? Name { get; set; }
    
    public virtual Place? Place { get; set; }
}