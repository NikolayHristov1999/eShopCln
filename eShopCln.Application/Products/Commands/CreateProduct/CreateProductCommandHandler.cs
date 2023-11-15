using eShopCln.Domain.Products;
using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Products.Commands.CreateProduct;

public sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<Guid>>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
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

        await _productRepository.AddAsync(product);

        return product.Id;
    }
}
