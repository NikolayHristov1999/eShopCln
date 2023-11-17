using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Products.Commands.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    decimal Price,
    int Quantity,
    string ShortDescription,
    string? Description,
    IEnumerable<Guid> CategoryIds)
    : IRequest<Result<Guid>>;