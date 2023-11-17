using eShopCln.Domain.Common.Repositories;

namespace eShopCln.Domain.Categories
{
    public interface ICategoryRepository : IBaseEntityRepository<Category>
    {
        public Task<Category?> GetByNameAsync(string name);

        public Task<IEnumerable<Category>> GetCategoriesByIdsAsync(IEnumerable<Guid> categoryIds);

        public Task<IEnumerable<Category>> GetAll(int page, int pageSize, bool includeProducts);
    }
}
