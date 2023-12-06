using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class LocationRepository : ILocationRepository
{
    private readonly StudenciakDbContext _context;

    public LocationRepository(StudenciakDbContext context)
    {
        _context = context;
    }
    public async Task<int> AddAsync(Location location)
    {
        await _context.Locations.AddAsync(location);
        await _context.SaveChangesAsync();
        return location.Id;
    }

    public async Task DeleteByIdAsync(int id)
    {
        var location = await _context.Locations.FindAsync(id);
        if (location != null) _context.Locations.Remove(location);
        await _context.SaveChangesAsync();
    }
}