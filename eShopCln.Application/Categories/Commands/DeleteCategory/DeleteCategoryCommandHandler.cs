using eShopCln.Domain.Categories;
using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Categories.Commands.DeleteCategory
{
    public sealed class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var dbCategory = await _categoryRepository.GetByIdAsync(request.Id);

            if (dbCategory is null)
            {
                return Result.Failure(new Error(
                    "Category.NotFound",
                    $"Category with id {request.Id} not found"));
            }

            await _categoryRepository.DeleteAsync(dbCategory);

            return Result.Success();
        }
    }
}
