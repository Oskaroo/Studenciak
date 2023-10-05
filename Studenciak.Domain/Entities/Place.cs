using Domain.Common;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities;

public class Place : BaseEntity<int>
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