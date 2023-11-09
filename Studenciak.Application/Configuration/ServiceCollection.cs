using System.Reflection;
using Application.User.Commands.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration;

public static class ServiceCollection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        
        return services;
    }
}