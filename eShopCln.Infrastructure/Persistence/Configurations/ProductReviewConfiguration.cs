using eShopCln.Domain.ProductReviews;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopCln.Infrastructure.Persistence.Configurations
{
    public class ProductReviewConfiguration : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder.ToTable("ProductReviews");

            builder.HasKey(pr => pr.Id);

            builder
                .OwnsOne(pr => pr.Rating);

            builder
                .Property(pr => pr.Comment)
                .HasMaxLength(1000);
        }
    }
}
