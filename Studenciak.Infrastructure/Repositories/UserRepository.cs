using System.Linq.Expressions;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly StudenciakDbContext _context;
    public UserRepository(StudenciakDbContext context)
    {
        _context = context;
    }
    public async Task<User> GetAllAsync()
    {
        var users = await _context.Users.ToListAsync();
        return users.FirstOrDefault();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }
    
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }
    public async Task<bool> UserExistsAsync(Expression<Func<User, bool>> predicate)
    {
        var userExists = await _context.Users
            .AnyAsync(predicate);
        return userExists;
    }
}