using Microsoft.Extensions.DependencyInjection;

namespace eShopCln.Application;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(ApplicationAssembly.Instance);
        });

        return services;
    }
}
