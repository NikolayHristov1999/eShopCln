using eShopCln.Domain.Categories;
using eShopCln.Domain.Products;
using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public CreateProductCommandHandler(
        IProductRepository productRepository,
        ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.CreateProduct(
            id: Guid.NewGuid(),
            price: request.Price,
            name: request.Name,
            quantity: request.Quantity,
            description: request.Description,
            shortDescription: request.ShortDescription);

        var categories = await _categoryRepository.GetCategoriesByIdsAsync(request.CategoryIds);

        foreach (var category in categories)
        {
            product.AddToCategory(category);
        }

        await _productRepository.AddAsync(product);

        return product.Id;
    }
}
