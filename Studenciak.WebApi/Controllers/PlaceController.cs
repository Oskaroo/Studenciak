using Microsoft.AspNetCore.Mvc;
using Application.Common.Models;
using Web.Services;

namespace Web.Controllers;

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
}