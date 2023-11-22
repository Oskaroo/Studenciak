using Application.Abstraction.Messaging;
using Application.Place.Dto;
using Domain.Repositories;
using Mapster;

namespace Application.Place.Queries.GetAll;

public class GetAllPlaceQueryHandler : IQueryHandler<GetAllPlaceQuery, List<PlaceDto>>
{
    private readonly IPlaceRepository _placeRepository;

    public GetAllPlaceQueryHandler(IPlaceRepository placeRepository)
    {
        _placeRepository = placeRepository;
    }
    public async Task<List<PlaceDto>> Handle(GetAllPlaceQuery request, CancellationToken cancellationToken)
    {
        var places = await _placeRepository.GetAllPlacesAsync();
        var placeDtos = places.Select(place => place.Adapt<PlaceDto>()).ToList();
        return placeDtos;
    }
}