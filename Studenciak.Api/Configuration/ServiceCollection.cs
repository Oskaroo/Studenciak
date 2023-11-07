namespace Web.Configuration;

public class ServiceCollection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); });
        services.AddScoped<ExceptionHandlingMiddleware>();
        return services;
    }
}