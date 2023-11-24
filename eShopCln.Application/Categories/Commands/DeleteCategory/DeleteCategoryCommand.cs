using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Categories.Commands.DeleteCategory
{
    public sealed record DeleteCategoryCommand(Guid Id) : IRequest<Result>;
}
