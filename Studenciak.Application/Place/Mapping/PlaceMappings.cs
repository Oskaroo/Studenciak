using Application.Place.Dto;
using Domain.ValueObjects;
using Mapster;

namespace Application.Place.Mapping;

public class PlaceMappings : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreatePlaceDto, Domain.Entities.Place>()
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Description, src => src.Description);
    }
}