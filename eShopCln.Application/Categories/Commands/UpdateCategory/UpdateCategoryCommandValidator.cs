using eShopCln.Domain.Categories;
using FluentValidation;

namespace eShopCln.Application.Categories.Commands.UpdateCategory;

public sealed class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryCommandValidator(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150)
            .MustAsync(IsNameUniqueAsync)
            .WithMessage(x => $"Category with name '{x.Name}' already exists.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .When(x => !string.IsNullOrEmpty(x.Description));
    }

    private async Task<bool> IsNameUniqueAsync(UpdateCategoryCommand categoryCommand, string name, CancellationToken cancellationToken)
    {
        return await _categoryRepository.IsNameUniqueAsync(name, categoryCommand.Id);
    }
}
