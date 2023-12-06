namespace Application.Place.Dto;

public class CreatePlaceDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int PlaceTypeId { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; } 
}