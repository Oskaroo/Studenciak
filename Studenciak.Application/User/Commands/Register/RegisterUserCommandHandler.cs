using Application.Abstraction.Messaging;
using Application.Security;
using Domain.Exceptions;
using Domain.Repositories;
using Mapster;

namespace Application.User.Commands.Register;

internal sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
{
    private readonly IGenericRepository<Domain.Entities.User, int> _repository;
    private readonly IPasswordManager _passwordManager;
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IGenericRepository<Domain.Entities.User, int> repository, IPasswordManager passwordManager, IUserRepository userRepository)
    {
        _repository = repository;
        _passwordManager = passwordManager;
        _userRepository = userRepository;
    }

    public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.UserExistsAsync(u => u.Email == request.UserDto.Email))
            throw new EmailTakenException();
        
        Domain.Entities.User user = request.UserDto.Adapt<Domain.Entities.User>();
        user.PasswordHash = _passwordManager.Secure(request.UserDto.Password);
        await _repository.AddAsync(user);
    }
}