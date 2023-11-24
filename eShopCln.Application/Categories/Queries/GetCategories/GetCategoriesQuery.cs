using eShopCln.Application.Categories.Queries.GetCategoryById;
using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Categories.Queries.GetCategories;

public sealed record GetCategoriesQuery() : IRequest<Result<IEnumerable<CategoryResponse>>>;
