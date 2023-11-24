namespace eShopCln.Application.Categories.Queries.GetCategoryById;

public sealed record CategoryResponse(Guid id, string Name, string? Description, int priority);
