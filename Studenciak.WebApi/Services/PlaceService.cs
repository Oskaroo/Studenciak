using Application.Common.Models;
using AutoMapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Web.Services;

public interface IPlaceService
{
    IEnumerable<PlaceDto> GetAll();
}

public class PlaceService : IPlaceService
{
    private readonly StudenciakDbContext _dbContext;
    private readonly IMapper _mapper;

    public PlaceService(StudenciakDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public IEnumerable<PlaceDto> GetAll()
    {
        var places = _dbContext.Places
            .Include(p => p.Location)
            .Include(p => p.FoodType)
            .ToList();
        var placesDtos = _mapper.Map<List<PlaceDto>>(places);
        return placesDtos;
    }
}