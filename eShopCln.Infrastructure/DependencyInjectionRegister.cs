using eShopCln.Domain.Common.Repositories;
using eShopCln.Infrastructure.Persistence;
using eShopCln.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShopCln.Infrastructure;

public static class DependencyInjectionRegister
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistance(configuration);
        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
    {
        //TODO: extract into a configuration file
        services.AddDbContext<EShopClnDbContext>(options =>
            options.UseSqlServer(configuration["Database:ConnectionString"]!));

        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}
