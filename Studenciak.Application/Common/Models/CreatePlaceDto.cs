using System.ComponentModel.DataAnnotations;
using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Common.Models;

public class CreatePlaceDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Location Location { get; set; }
    public PlaceType TypeOfPlace { get; set; }
    public string FoodType { get; set; }
}