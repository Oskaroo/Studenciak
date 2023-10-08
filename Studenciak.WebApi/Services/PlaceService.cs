using Application.Common.Exceptions;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Web.Services;

public interface IPlaceService
{
    IEnumerable<PlaceDto> GetAll();
    PlaceDto GetById(int id);
    int Create(CreatePlaceDto dto);
    void Delete(int id);
}

public class PlaceService : IPlaceService
{
    private readonly StudenciakDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly ILogger _logger;

    public PlaceService(StudenciakDbContext dbContext, IMapper mapper, ILogger<PlaceService> logger)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _logger = logger;
    }
    
    public IEnumerable<PlaceDto> GetAll()
    {
        var places = _dbContext.Places
            .Include(p => p.Location)
            .ToList();
        var placesDtos = _mapper.Map<List<PlaceDto>>(places);
        return placesDtos;
    }
    public PlaceDto GetById(int id)
    {
        var place = _dbContext.Places
            .Include(r => r.Location)
            .FirstOrDefault(p => p.Id == id);
        if (place is null) 
            throw new NotFoundException("Restaurant not found");;
        var result = _mapper.Map<PlaceDto>(place);
        return result;
    }
    public int Create(CreatePlaceDto dto)
    {
        var place = _mapper.Map<Place>(dto);
        _dbContext.Places.Add(place);
        _dbContext.SaveChanges();
        return place.Id;
    }
    public void Delete(int id)
    {
        _logger.LogError($"Place with id: {id} DELETE action invoked");
        var place = _dbContext.Places
            .FirstOrDefault(p => p.Id == id);
        if (place is null)
            throw new NotFoundException("Restaurant not found");
        _dbContext.Places.Remove(place);
        _dbContext.SaveChanges();
    }
}