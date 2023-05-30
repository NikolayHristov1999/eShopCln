using eShopCln.Domain.Common.Repositories;
using eShopCln.Infrastructure.Persistence;
using eShopCln.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCln.Infrastructure;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddPersistance();
        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        //TODO: extract into a configuration file
        services.AddDbContext<EShopClnDbContext>(options =>
            options.UseSqlServer("Server=.;Database=EShopCln;TrustServerCertificate=True;Trusted_Connection=True"));

        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
