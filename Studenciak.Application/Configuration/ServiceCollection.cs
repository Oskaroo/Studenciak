using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        
        return services;
    }
}