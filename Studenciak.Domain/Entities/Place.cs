using Domain.ValueObjects;

namespace Domain.Entities;

public class Place
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    
    
    public int TypeOfPlaceId { get; set; }
    public PlaceType TypeOfPlace { get; set; }
    
    public virtual ICollection<User> FavoritedByUsers { get; set; }
    public virtual ICollection<User> VisitedByUsers { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
    
    public int PlaceLocationId { get; set; }
    public Location PlaceLocation { get; set; }
}