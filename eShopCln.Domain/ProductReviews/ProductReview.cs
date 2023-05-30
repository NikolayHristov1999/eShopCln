using eShopCln.Domain.Common.Models;
using eShopCln.Domain.Common.ValueObjects;
using eShopCln.Domain.Products;

namespace eShopCln.Domain.ProductReviews;

public class ProductReview : AggregateRoot
{
    private ProductReview(
        Guid id,
        Guid productId,
        string comment) 
        : base(id)
    {
        ProductId = productId;
        Comment = comment;
    }

    public Rating Rating { get; private set; }

    public string Comment { get; private set; }

    public Guid ProductId { get; private set; }

    public Product Product { get; private set; }

    public static ProductReview CreateProductReview(
        Guid id,
        Guid productId,
        string comment)
        => new(
            id,
            productId,
            comment);
}
