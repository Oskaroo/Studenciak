
namespace Application.User.Dto;

public class RegisterDto
{
    public string Email { get; set; }
    public string FirstName { get; set; }

    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}