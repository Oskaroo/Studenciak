using Application.Abstraction;
using Application.Security;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Infrastructure;

public static class ServiceCollection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPasswordManager, PasswordManager>();
        services.AddSingleton<IPasswordHasher<User>, PasswordHasher<User>>();
        services.AddScoped<IDatabaseSeeder, DatabaseSeeder>();

        
        return services;
    }
}