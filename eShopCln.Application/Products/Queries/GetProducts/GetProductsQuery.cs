using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Products.Queries.GetProducts;

public sealed record GetProductsQuery() : IRequest<Result<IEnumerable<ProductItemResponse>>>;
