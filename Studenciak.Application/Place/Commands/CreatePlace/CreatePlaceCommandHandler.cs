using Application.Abstraction.Messaging;
using Domain.Repositories;
using Domain.ValueObjects;

namespace Application.Place.Commands.CreatePlace;

public class CreatePlaceCommandHandler : ICommandHandler<CreatePlaceCommand>
{
    private readonly IGenericRepository<Domain.Entities.Place, int> _repository;
    private readonly IPlaceRepository _placeRepository;
    private readonly ILocationRepository _locationRepository;

    public CreatePlaceCommandHandler(IGenericRepository<Domain.Entities.Place, int> repository, IPlaceRepository placeRepository, ILocationRepository locationRepository)
    {
        _repository = repository;
        _placeRepository = placeRepository;
        _locationRepository = locationRepository;
    }

    public async Task Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var location = new Location
            {
                Name = request.PlaceDto.Name,
                Latitude = request.PlaceDto.Latitude,
                Longitude = request.PlaceDto.Longitude
            };
            await _locationRepository.AddAsync(location);
            var place = new Domain.Entities.Place
            {
                Name = request.PlaceDto.Name,
                Description = request.PlaceDto.Description,
                TypeOfPlaceId = request.PlaceDto.PlaceTypeId,
                PlaceLocation = location
            };
            await _placeRepository.AddAsync(place);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}