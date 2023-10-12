using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class User : BaseEntity<int>
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Nationality { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
}