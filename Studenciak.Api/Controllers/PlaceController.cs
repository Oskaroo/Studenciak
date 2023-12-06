using Application.Place.Commands;
using Application.Place.Commands.CreatePlace;
using Application.Place.Commands.DeletePlace;
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

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreatePlaceDto placeDto)
    {
        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage)
                .ToList();
            return BadRequest(new { errors });
        }

        await _mediator.Send(new CreatePlaceCommand(placeDto));
        return Ok();
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeletePlaceCommand(id));
        return Ok();
    }
}