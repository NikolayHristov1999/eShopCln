using eShopCln.Domain.Categories;
using Microsoft.EntityFrameworkCore;

namespace eShopCln.Infrastructure.Persistence.Repositories
{
    public class CategoryRepository : BaseEntityRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(EShopClnDbContext context)
            : base(context)
        {
        }

        public Task<Category?> GetByNameAsync(string name)
        {
            return _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<IEnumerable<Category>> GetCategoriesByIdsAsync(IEnumerable<Guid> categoryIds)
        {
            return await _context.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToListAsync();
        }

        public Task<IEnumerable<Category>> GetAll(int page, int pageSize, bool includeProducts)
        {
            throw new NotImplementedException();
        }
    }
}
