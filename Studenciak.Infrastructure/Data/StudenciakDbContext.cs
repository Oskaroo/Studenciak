using Application.Common.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class StudenciakDbContext : DbContext, IStudenciakDbContext
{
    #region Ctor
    private readonly string _connectionString = "Server=(localdb)\\mssqllocaldb;Database=Studenciak;Trusted_Connection=True;MultipleActiveResultSets=true";

    public StudenciakDbContext(DbContextOptions<StudenciakDbContext> options) : base(options)
    {
    }
    #endregion
    
    #region DbSet
    public DbSet<Place> Places { get; set; }
    public DbSet<User> Users { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Place>()
            .Property(p => p.Name)
            .IsRequired();
        modelBuilder.Entity<Place>()
            .Property(p => p.TypeOfPlace)
            .IsRequired();
        modelBuilder.Entity<Place>()
            .Property(p => p.TypeOfPlace)
            .HasConversion<string>();
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
    
    #region Methods
    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
    #endregion
}