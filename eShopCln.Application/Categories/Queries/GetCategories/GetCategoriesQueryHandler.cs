using eShopCln.Application.Categories.Queries.GetCategoryById;
using eShopCln.Domain.Categories;
using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Categories.Queries.GetCategories;

public sealed class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, Result<IEnumerable<CategoryResponse>>>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<IEnumerable<CategoryResponse>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();

        var categoriesResponse = categories.Select(c => new CategoryResponse(c.Id, c.Name, c.Description, c.Priority)).ToList();

        return categoriesResponse;
    }
}
