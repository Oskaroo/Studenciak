using Application.Abstraction.Messaging;
using Domain.Repositories;

namespace Application.Place.Commands.DeletePlace;

public class DeletePlaceCommandHandler : ICommandHandler<DeletePlaceCommand>
{
    private readonly IPlaceRepository _placeRepository;
    private readonly ILocationRepository _locationRepository;

    public DeletePlaceCommandHandler(IPlaceRepository placeRepository, ILocationRepository locationRepository)
    {
        _placeRepository = placeRepository;
        _locationRepository = locationRepository;
    }
    public async Task Handle(DeletePlaceCommand request, CancellationToken cancellationToken)
    {
        await _placeRepository.DeleteByIdAsync(request.placeId);
        await _locationRepository.DeleteByIdAsync(request.placeId);
    }
}