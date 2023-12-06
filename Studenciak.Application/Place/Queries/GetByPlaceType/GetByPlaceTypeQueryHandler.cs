using Application.Abstraction.Messaging;
using Application.Place.Dto;
using Domain.Repositories;
using Mapster;

namespace Application.Place.Queries.GetByPlaceType;

public class GetByPlaceTypeQueryHandler : IQueryHandler<GetByPlaceTypeQuery, List<PlaceDto>>
{
    private readonly IPlaceRepository _placeRepository;

    public GetByPlaceTypeQueryHandler(IPlaceRepository placeRepository)
    {
        _placeRepository = placeRepository;
    }

    public async Task<List<PlaceDto>> Handle(GetByPlaceTypeQuery request, CancellationToken cancellationToken)
    {
        var places = await _placeRepository.GetAllPlacesByPlaceTypeAsync(request.TypeOfPlaceId);
        var placeDtos = places.Select(place => place.Adapt<PlaceDto>()).ToList();
        return placeDtos;
    }
}