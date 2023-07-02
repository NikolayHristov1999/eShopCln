using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Products.Commands.UpdateProduct;

public sealed record UpdateProductCommand(
    Guid Id,
    string Name,
    decimal Price,
    int Quantity,
    string ShortDescription,
    string? Description) : IRequest<Result>;
