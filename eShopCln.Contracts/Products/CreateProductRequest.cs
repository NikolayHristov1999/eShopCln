namespace eShopCln.Contracts.Products;

public sealed record CreateProductRequest(
    string Name, 
    decimal Price,
    string ShortDescription,
    string? Description,
    int Quantity,
    IEnumerable<Guid> CategoryIds);
