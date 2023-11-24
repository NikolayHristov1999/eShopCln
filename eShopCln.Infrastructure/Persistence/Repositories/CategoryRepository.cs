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

        public async Task<Category?> GetByNameAsync(string name)
            => await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);

        public async Task<IEnumerable<Category>> GetCategoriesByIdsAsync(IEnumerable<Guid> categoryIds)
            => await _context.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToListAsync();

        public async Task<IEnumerable<Category>> GetAllAsync(bool includeProducts = false)
            => includeProducts
                ? await _context.Categories.Include(c => c.Products).ToListAsync()
                : await _context.Categories.ToListAsync();


        public async Task<bool> IsNameUniqueAsync(string name, Guid? id = null)
            => !await _context.Categories.AnyAsync(x => x.Name == name && x.Id != id);
    }
}
