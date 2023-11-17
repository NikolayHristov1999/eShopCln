using eShopCln.Domain.Categories;
using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Categories.Commands.CreateCategory;

public sealed class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Result<Guid>>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<Guid>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = Category.Create(
            name: request.Name,
            description: request.Description,
            priority: request.Priority);

        await _categoryRepository.AddAsync(category);

        return category.Id;
    }
}
