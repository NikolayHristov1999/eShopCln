using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Categories.Queries.GetCategoryById;

public sealed record GetCategoryByIdQuery(Guid Id) : IRequest<Result<CategoryResponse>>;