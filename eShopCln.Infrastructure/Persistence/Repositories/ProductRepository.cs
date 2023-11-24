using eShopCln.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace eShopCln.Infrastructure.Persistence.Repositories
{
    public sealed class ProductRepository : BaseEntityRepository<Product>, IProductRepository
    {
        public ProductRepository(EShopClnDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
            => await _context.Products.ToListAsync();
    }
}
