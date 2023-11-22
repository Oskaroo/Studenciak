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

    public Task AddAsync(Place place)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Place place)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}