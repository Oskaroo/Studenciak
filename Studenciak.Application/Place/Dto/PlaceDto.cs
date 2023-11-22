namespace Application.Place.Dto;

public class PlaceDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
    public int PlaceLocationId { get; set; }
    public int TypeOfPlaceId { get; set; }
}