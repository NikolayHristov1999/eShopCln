using eShopCln.Domain.Common.Repositories;

namespace eShopCln.Domain.Categories
{
    public interface ICategoryRepository : IBaseEntityRepository<Category>
    {
        public Task<Category?> GetByNameAsync(string name);

        public Task<IEnumerable<Category>> GetWithProductsAsync();
    }
}
