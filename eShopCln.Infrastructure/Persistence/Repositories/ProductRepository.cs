using eShopCln.Domain.Products;

namespace eShopCln.Infrastructure.Persistence.Repositories
{
    public sealed class ProductRepository : BaseEntityRepository<Product>, IProductRepository
    {
        public ProductRepository(EShopClnDbContext context) : base(context)
        {
        }
    }
}
