using Microsoft.AspNetCore.Mvc;
using Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Web.Services;

namespace Web.Controllers;
[Route("api/place")]
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