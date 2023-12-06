using Application.Abstraction.Messaging;
using Application.Place.Dto;

namespace Application.Place.Commands.DeletePlace;

public sealed record DeletePlaceCommand(int placeId): ICommand<PlaceDto>, ICommand;