using Microsoft.AspNetCore.Mvc;

namespace eShopCln.API;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAutoMapper(AssemblyReference.Instance);

        services.AddApiVersioning(config =>
        {
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.DefaultApiVersion = new ApiVersion(1, 0);
        });

        return services;
    }
}
