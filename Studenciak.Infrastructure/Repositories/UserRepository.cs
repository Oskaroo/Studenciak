using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly StudenciakDbContext _context;
    public UserRepository(StudenciakDbContext context)
    {
        _context = context;
    }
}