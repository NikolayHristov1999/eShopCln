using eShopCln.Domain.Categories;
using eShopCln.Domain.Products;
using eShopCln.Infrastructure.Persistence;
using eShopCln.Infrastructure.Persistence.Interceptors;
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
        services.AddSingleton<UpdateSoftDeletableEntityInterceptor>();
        services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

        //TODO: extract into a configuration file
        services.AddDbContext<EShopClnDbContext>((sp, options) =>
        {
            var updateInterceptor = sp.GetRequiredService<UpdateSoftDeletableEntityInterceptor>();
            var deleteInterceptor = sp.GetRequiredService<UpdateAuditableEntitiesInterceptor>();

            options.UseSqlServer(configuration["Database:ConnectionString"]!)
                .AddInterceptors(
                    deleteInterceptor,
                    updateInterceptor);
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();

        return services;
    }
}
