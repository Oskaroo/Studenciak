using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class StudenciakDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<PlaceType> PlaceTypes { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Location> Locations { get; set; }
    
    
    private readonly List<Role> _roles;
    private readonly List<Place> _places;
    private readonly List<Location> _locations;
    private readonly List<User> _users;
    private readonly List<PlaceType> _placeTypes;
    public StudenciakDbContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}