using Application.Abstraction.Messaging;
using Application.Place.Dto;
using Domain.Repositories;
using Mapster;

namespace Application.Place.Queries.GetById;

public class GetPlaceByIdQueryHandler : IQueryHandler<GetPlaceByIdQuery, PlaceDto>
{
    private readonly IPlaceRepository _placeRepository;

    public GetPlaceByIdQueryHandler(IPlaceRepository placeRepository)
    {
        _placeRepository = placeRepository;
    }
    public async Task<PlaceDto> Handle(GetPlaceByIdQuery request, CancellationToken cancellationToken)
    {
        var place = await _placeRepository.GetPlaceByIdAsync(request.placeId);
        var placeDto = place.Adapt<PlaceDto>();
        return placeDto;
    }
}