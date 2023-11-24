using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Products.Commands.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id) : IRequest<Result>;
