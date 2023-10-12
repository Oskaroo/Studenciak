using Microsoft.AspNetCore.Mvc;
using Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Web.Services;

namespace Web.Controllers;
[Route("api/place")]
[ApiController]
[Authorize]
public class PlaceController : ControllerBase
{
    private readonly IPlaceService _placeService;

    public PlaceController(IPlaceService placeService)
    {
        _placeService = placeService;
    }


    [HttpGet]
    public ActionResult<IEnumerable<PlaceDto>> GetAll()
    {
        var placesDtos = _placeService.GetAll();
        return Ok(placesDtos);
    }
    [HttpGet("{id}")]
    public ActionResult<PlaceDto> Get([FromRoute] int id)
    {
        var place = _placeService.GetById(id);
            
        return Ok(place);
    }
    [HttpPost]
    public ActionResult CreateRestaurant([FromBody] CreatePlaceDto dto)
    {
        var id =_placeService.Create(dto);

        return Created($"/api/restaurant/{id}", null);
    }
    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        _placeService.Delete(id);
            
        return NoContent();
    }
    [HttpPut("{id}")]
    public ActionResult<PlaceDto> Update([FromBody] UpdatePlaceDto dto, [FromRoute] int id)
    {
        _placeService.Update(id, dto);
        return Ok();
    }
}