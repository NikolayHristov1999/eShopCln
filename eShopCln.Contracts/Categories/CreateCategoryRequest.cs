namespace eShopCln.Contracts.Categories;

public sealed record CreateCategoryRequest(string Name, string? Description, int Priority);
