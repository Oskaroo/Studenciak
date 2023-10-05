using Application.Common.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<StudenciakDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(StudenciakDbContext).Assembly.FullName)), ServiceLifetime.Transient);
        services.AddScoped<IStudenciakDbContext>(provider => provider.GetService<StudenciakDbContext>());
        return services;
    }
}