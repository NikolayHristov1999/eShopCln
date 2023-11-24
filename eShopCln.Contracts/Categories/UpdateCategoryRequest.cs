namespace eShopCln.Contracts.Categories;

public sealed record UpdateCategoryRequest(string Name, string? Description, int Priority);
