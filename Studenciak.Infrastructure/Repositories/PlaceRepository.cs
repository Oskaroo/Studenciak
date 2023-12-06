using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PlaceRepository : IPlaceRepository
{
    private readonly StudenciakDbContext _context;
    public PlaceRepository(StudenciakDbContext context)
    {
        _context = context;
    }
    public async Task<Place> GetPlaceByIdAsync(int id)
    {
        var place = await _context.Places.FirstOrDefaultAsync( p => p.Id == id);
        return place;
    }
    
    public async Task<IEnumerable<Place>> GetAllPlacesAsync()
    {
        var places = await _context.Places.ToListAsync();
        return places;
    }

    public async Task<IEnumerable<Place>> GetAllPlacesByPlaceTypeAsync(int placeTypeId)
    {
        var places = await _context.Places
            .Where(p => p.TypeOfPlaceId == placeTypeId)
            .ToListAsync();
        return places;
    }

    public async Task<int> AddAsync(Place place)
    {
        await _context.Places.AddAsync(place);
        await _context.SaveChangesAsync();
        return place.Id;
    }

    public Task UpdateAsync(Place place)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var place = await _context.Places.FirstOrDefaultAsync(p => p.Id == id);
        _context.Places.Remove(place);
    }
}