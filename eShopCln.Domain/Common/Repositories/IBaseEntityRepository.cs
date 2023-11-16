using eShopCln.Domain.Common.Models;

namespace eShopCln.Domain.Common.Repositories
{
    public interface IBaseEntityRepository<T> where T : Entity
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task<T?> GetByIdAsync(Guid id);

        Task DeleteAsync(T entity);

        Task<IEnumerable<T>> GetAllAsync();
    }
}
