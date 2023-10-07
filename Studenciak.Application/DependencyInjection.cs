using Application.Common.Mappings;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddAplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<PlaceMappingProfile>(); // Add your mapping profile here
        });

        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        
        return services;
    }
}