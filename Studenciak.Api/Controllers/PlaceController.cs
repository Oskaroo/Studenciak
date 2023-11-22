using Application.Place.Dto;
using Application.Place.Queries.GetAll;
using Application.Place.Queries.GetById;
using Application.Place.Queries.GetByPlaceType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaceController : ControllerBase
{
    private readonly IMediator _mediator;

    public PlaceController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetPlaceById(int id)
    {
        var place = await _mediator.Send(new GetPlaceByIdQuery(id));
        return Ok(place);
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlaceDto>>> GetAllPlaces()
    {
        var places = await _mediator.Send(new GetAllPlaceQuery());
        return Ok(places);
    }
    [HttpGet("type/{placeTypeId}")]
    public async Task<ActionResult<IEnumerable<PlaceDto>>> GetPlacesByPlaceType(int placeTypeId)
    {
        var places = await _mediator.Send(new GetByPlaceTypeQuery(placeTypeId));
        return Ok(places);
    }
}