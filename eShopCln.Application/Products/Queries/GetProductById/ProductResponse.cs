namespace eShopCln.Application.Products.Queries.GetProductById;

public sealed record ProductResponse(Guid Id, string Name, decimal Price, string ShortDescription, int Quantity, string Description);