using Application.Abstraction.Messaging;
using Application.Place.Dto;

namespace Application.Place.Queries.GetById;

public sealed record GetPlaceByIdQuery(int placeId) : IQuery<PlaceDto>;