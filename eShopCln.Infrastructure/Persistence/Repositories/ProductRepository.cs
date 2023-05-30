using eShopCln.Domain.Common.Repositories;
using eShopCln.Domain.Products;

namespace eShopCln.Infrastructure.Persistence.Repositories
{
    public sealed class ProductRepository : IProductRepository
    {
        private readonly EShopClnDbContext _context;

        public ProductRepository(EShopClnDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
