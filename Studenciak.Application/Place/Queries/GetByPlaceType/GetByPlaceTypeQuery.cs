using Application.Abstraction.Messaging;
using Application.Place.Dto;

namespace Application.Place.Queries.GetByPlaceType
{
    public record GetByPlaceTypeQuery(int TypeOfPlaceId) : IQuery<List<PlaceDto>>;
}