using System.Linq.Expressions;
using Domain.Entities;
namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    public Task<bool> UserExistsAsync(Expression<Func<User, bool>> predicate);
}