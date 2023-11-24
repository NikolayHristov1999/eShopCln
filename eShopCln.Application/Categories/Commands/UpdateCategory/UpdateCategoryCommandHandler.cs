using eShopCln.Domain.Categories;
using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var dbCategory = await _categoryRepository.GetByIdAsync(request.Id);

        if (dbCategory is null) 
        {
            return Result.Failure(new Error(
                "Category.NotFound",
                $"Category with id {request.Id} not found"));
        }

        dbCategory.Update(request.Name, request.Description, request.Priority);

        await _categoryRepository.UpdateAsync(dbCategory);

        return Result.Success();
    }
}
