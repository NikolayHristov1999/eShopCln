using eShopCln.Domain.Products;
using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Products.Queries.GetProductById;

public sealed class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductResponse>>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductResponse>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(request.Id);

        if (product is null)
        {
            return Result.Failure<ProductResponse>(new Error(
                "Product.NotFound",
                $"Product with id {request.Id} not found"));
        }

        var response = new ProductResponse(product.Id, product.Name, product.Price, product.ShortDescription, product.Quantity, product.Description);

        return response;
    }
}
