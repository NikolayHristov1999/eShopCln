using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Categories.Commands.CreateCategory;

public sealed record CreateCategoryCommand(
    string Name, 
    string Description,
    int Priority) 
    : IRequest<Result<Guid>>;
