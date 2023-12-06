using Application.Abstraction.Messaging;
using Application.Place.Dto;

namespace Application.Place.Commands.CreatePlace;

public sealed record CreatePlaceCommand(CreatePlaceDto PlaceDto) : ICommand;