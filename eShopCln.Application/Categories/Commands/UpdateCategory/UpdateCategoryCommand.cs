using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Categories.Commands.UpdateCategory;

public sealed record UpdateCategoryCommand(string Name, string Description, int Priority) : IRequest<Result>
{
    public Guid Id { get; set; }
}
