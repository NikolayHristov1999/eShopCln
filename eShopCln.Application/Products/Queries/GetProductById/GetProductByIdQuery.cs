using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Products.Queries.GetProductById;

public record GetProductByIdQuery(Guid Id) : IRequest<Result<ProductResponse>>;