using eShopCln.Domain.Common.Models;
using eShopCln.Domain.Products;

namespace eShopCln.Domain.Categories;

public sealed class Category : DeletableAggregateRoot
{
    private readonly List<Product> _products = new();

    private Category(Guid id, string name, string description, int priority) : base(id)
    {
        Name = name;
        Description = description;
        Priority = priority;
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public int Priority { get; set; }

    public IReadOnlyList<Product> Products => _products.ToList();

    public static Category Create(string name, string description, int priority = 0)
    {
        return new Category(Guid.NewGuid(), name, description, priority);
    }

    public Category Update(string name, string description, int priority)
    {
        Name = name;
        Description = description;
        Priority = priority;

        return this;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
}
