using Application.Common.Interfaces;
using Application.Common.Models;
using FluentValidation;

namespace Application.Validators;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
    private readonly IStudenciakDbContext _dbContext;

    public RegisterUserDtoValidator(IStudenciakDbContext dbContext)
    {
        _dbContext = dbContext;
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Password)
            .MinimumLength(6);
        RuleFor(x => x.ConfirmPassword)
            .Equal(e => e.Password);
        RuleFor(x => x.Email).Custom((value, context) =>
        {
            var emailInUse = _dbContext.Users.Any(u => u.Email == value);
            if (emailInUse)
            {
                context.AddFailure("Email", "That email is taken");
            }
        });

    }
}