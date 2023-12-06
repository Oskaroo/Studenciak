using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrastructure.EntitiesConfiguration;

public class LocationsConfiguration : IEntityTypeConfiguration<Location>
{
    
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(l => l.Id);
        builder.Property(l => l.Latitude)
            .IsRequired();
        builder.Property(l => l.Longitude)
            .IsRequired();
        builder.Property(l => l.Name)
            .IsRequired();
        builder.HasOne(l => l.Place)
            .WithOne(p => p.PlaceLocation)
            .HasForeignKey<Place>(p => p.PlaceLocationId);
    }
}