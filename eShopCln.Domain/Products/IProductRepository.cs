using eShopCln.Domain.Common.Repositories;

namespace eShopCln.Domain.Products
{
    public interface IProductRepository : IBaseEntityRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
    }
}
