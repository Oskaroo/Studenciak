using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Common.Models;

public class UpdatePlaceDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Location Location { get; set; }
    public PlaceType TypeOfPlace { get; set; }
}