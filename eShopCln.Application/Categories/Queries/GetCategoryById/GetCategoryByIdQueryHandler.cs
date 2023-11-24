using eShopCln.Domain.Categories;
using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Categories.Queries.GetCategoryById;

public sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<CategoryResponse>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category is null)
        {
            return Result.Failure<CategoryResponse>(new Error(
                "Category.NotFound",
                $"Category with id {request.Id} not found"));
        }

        var categoryResponse = new CategoryResponse(category.Id, category.Name, category.Description, category.Priority);

        return categoryResponse;
    }
}
