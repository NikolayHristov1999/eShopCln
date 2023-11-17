using eShopCln.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopCln.Infrastructure.Persistence.Configurations
{
    public sealed class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            ConfigureCategoryTable(builder);
        }

        public void ConfigureCategoryTable(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .HasMaxLength(150);

            builder
                .Property(c => c.Description)
                .HasMaxLength(10_000);

            builder
                .HasMany(c => c.Products)
                .WithMany(p => p.Categories)
                .UsingEntity(j => j.ToTable("ProductCategories"));
        }
    }
}
