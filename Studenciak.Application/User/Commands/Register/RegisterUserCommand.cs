using Application.Abstraction.Messaging;
using Application.User.Dto;

namespace Application.User.Commands.Register;

public sealed record RegisterUserCommand(RegisterDto UserDto) : ICommand;