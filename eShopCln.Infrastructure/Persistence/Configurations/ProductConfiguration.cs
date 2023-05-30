using eShopCln.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopCln.Infrastructure.Persistence.Configurations
{
    public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            ConfigureProductsTable(builder);
        }

        private void ConfigureProductsTable(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasMaxLength(150);

            builder.OwnsOne(p => p.AverageRating);

            builder
                .HasMany(p => p.Reviews)
                .WithOne(pr => pr.Product)
                .HasForeignKey(pr => pr.ProductId);
        }
    }
}
