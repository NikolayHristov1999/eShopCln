namespace eShopCln.Domain.Products
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);

        Task<Product?> GetByIdAsync(Guid id);

        Task UpdateAsync(Product product);
    }
}
