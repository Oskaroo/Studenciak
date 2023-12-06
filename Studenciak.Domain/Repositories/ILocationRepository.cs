using Domain.ValueObjects;

namespace Domain.Repositories;

public interface ILocationRepository
{
    public Task<int> AddAsync(Location location);
    public Task DeleteByIdAsync(int id);
}