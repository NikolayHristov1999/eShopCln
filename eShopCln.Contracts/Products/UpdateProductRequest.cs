namespace eShopCln.Contracts.Products;

public sealed record UpdateProductRequest(
    Guid productId,
    string Name,
    decimal Price,
    string ShortDescription,
    string? Description,
    int Quantity);