using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IStudenciakDbContext
{
    DbSet<Place> Places { get; }
    DbSet<User> Users { get; }
    Task<int> SaveChangesAsync();
}