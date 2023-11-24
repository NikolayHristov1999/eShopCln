namespace eShopCln.Application.Products.Queries.GetProducts;

public sealed record ProductItemResponse(Guid Id, string Name, decimal Price, int Quantity);
