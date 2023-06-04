using eShopCln.Domain.Products;

namespace eShopCln.Domain.Common.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task<Product?> GetByIdAsync(Guid id);
    }
}
