namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string PasswordHash { get; set; }
    
    public virtual ICollection<Place>? FavoritePlaces { get; set; }
    public virtual ICollection<Place>? VisitedPlaces { get; set; }
    public virtual ICollection<Review>? Reviews { get; set; }


    public int UserRoleId { get; set; } = 2;
    public Role UserRole { get; set; }
}