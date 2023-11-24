using eShopCln.Domain.Common.Models;
using eShopCln.Domain.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eShopCln.Infrastructure.Persistence.Repositories
{
    public abstract class BaseEntityRepository<T> : IBaseEntityRepository<T>
        where T : Entity
    {
        protected readonly EShopClnDbContext _context;

        public BaseEntityRepository(EShopClnDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _context.AddAsync(entity);

            //TODO: remove as no longer needed
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
