using Domain.Entities;

namespace Domain.ValueObjects;

public class Location
{
    public int Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public int PlaceId { get; set; }
    public Place Place { get; set; }
}