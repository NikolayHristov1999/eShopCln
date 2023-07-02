namespace eShopCln.Contracts.Products;

public sealed record UpdateProductRequest(
    string Name,
    decimal Price,
    string ShortDescription,
    string? Description,
    int Quantity);