using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Common.Models;

public class PlaceDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Location Location { get; set; }
    public PlaceType Type { get; set; }
    public string FoodType { get; set; } // For restaurants, specify the type of food (e.g., Chinese, Fast Food)
    public double Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}