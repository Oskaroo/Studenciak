using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StudenciakDbContext : DbContext, IStudenciakDbContext
{
    #region Ctor

    public StudenciakDbContext(DbContextOptions<StudenciakDbContext> options) : base(options)
    {
    }
    #endregion
    
    #region DbSet
    public DbSet<Place> Places { get; set; }
    #endregion
    
    #region Methods
    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
    #endregion
}