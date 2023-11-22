using Domain.Entities;

namespace Domain.Repositories;

public interface IPlaceRepository
{
    public Task<Place> GetPlaceByIdAsync(int id);
    public Task<IEnumerable<Place>> GetAllPlacesAsync();
    public Task AddAsync(Place place);
    public Task UpdateAsync(Place place);
    public Task DeleteByIdAsync(int id);
}