using eShopCln.Domain.Common.Models;
using eShopCln.Domain.Common.ValueObjects;
using eShopCln.Domain.ProductReviews;

namespace eShopCln.Domain.Products;

public sealed class Product : AggregateRoot
{
    private readonly List<ProductReview> _productReviews = new();

    public decimal Price { get; private set; }

    public string Name { get; private set; }

    public string? ShortDescription { get; private set; }

    public string? Description { get; private set; }

    public int Quantity { get; private set; }

    public AverageRating AverageRating { get; private set; }

    public IReadOnlyCollection<ProductReview> Reviews => _productReviews.AsReadOnly();

    private Product(
        Guid id,
        decimal price,
        string name,
        int quantity,
        string? shortDescription,
        string? description)
        : base(id)
    {
        Price = price;
        Name = name;
        Quantity = quantity;
        ShortDescription = shortDescription;
        Description = description;
    }

    public static Product CreateProduct(
        Guid id,
        decimal price,
        string name,
        int quantity,
        string? shortDescription,
        string? description)
    {
        var product = new Product(
            id,
            price,
            name,
            quantity,
            shortDescription,
            description);

        product.AverageRating = AverageRating.CreateNew(0);
        return product;
    }

    public void Update(
        string name,
        string shortDescription,
        string? description,
        decimal price,
        int quantity)
    {
        Name = name;
        ShortDescription = shortDescription;
        Description = description;
        Price = price;
        Quantity = quantity;
    }
}
