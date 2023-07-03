using eShopCln.Domain.ProductReviews;
using eShopCln.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace eShopCln.Infrastructure.Persistence;

public sealed class EShopClnDbContext : DbContext
{
    public EShopClnDbContext(DbContextOptions options) 
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<ProductReview> ProductReviews { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(InfrastructureAssembly.Instance);

        base.OnModelCreating(modelBuilder);
    }
}
