using eShopCln.Domain.Common.Repositories;

namespace eShopCln.Domain.Categories
{
    public interface ICategoryRepository : IBaseEntityRepository<Category>
    {
        Task<Category?> GetByNameAsync(string name);

        Task<IEnumerable<Category>> GetCategoriesByIdsAsync(IEnumerable<Guid> categoryIds);

        Task<IEnumerable<Category>> GetAllAsync(bool includeProducts = false);

        Task<bool> IsNameUniqueAsync(string name, Guid? id = null);
    }
}
