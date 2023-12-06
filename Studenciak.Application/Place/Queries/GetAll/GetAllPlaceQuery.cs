using Application.Abstraction.Messaging;
using Application.Place.Dto;

namespace Application.Place.Queries.GetAll;

public record GetAllPlaceQuery() : IQuery<List<PlaceDto>>;
