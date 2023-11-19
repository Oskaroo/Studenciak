using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntitiesConfiguration;

public class UsersConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.Property(u => u.FirstName).IsRequired();
        builder.Property(u => u.LastName).IsRequired();
        builder.Property(u => u.Email).IsRequired();
        builder.Property(u => u.PasswordHash).IsRequired();
        builder.Property(u => u.DateOfBirth).IsRequired(false);
        builder.HasMany(u => u.FavoritePlaces)
            .WithMany(p => p.FavoritedByUsers)
            .UsingEntity(j => j.ToTable("UserFavoritePlaces"));

        builder.HasMany(u => u.VisitedPlaces)
            .WithMany(p => p.VisitedByUsers)
            .UsingEntity(j => j.ToTable("UserVisitedPlaces"));
    }
}