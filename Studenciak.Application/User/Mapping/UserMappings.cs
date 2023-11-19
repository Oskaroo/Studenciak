using Application.User.Dto;
using Mapster;

namespace Application.User.Mapping;

public class UserMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<RegisterDto, Domain.Entities.User>()
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.DateOfBirth, src => src.DateOfBirth)
            .Map(dest => dest.PasswordHash, src => src.Password);
        config.ForType<Domain.Entities.User, RegisterDto>()
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.DateOfBirth, src => src.DateOfBirth)
            .Map(dest => dest.Password, src => src.PasswordHash);
    }
}