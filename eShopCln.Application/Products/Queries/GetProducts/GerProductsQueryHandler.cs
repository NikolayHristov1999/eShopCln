using eShopCln.Domain.Products;
using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Products.Queries.GetProducts;

public sealed class GerProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<IEnumerable<ProductItemResponse>>>
{
    private readonly IProductRepository _productRepository;

    public GerProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<IEnumerable<ProductItemResponse>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var dbProducts = await _productRepository.GetAllAsync();

        var productsResponse = dbProducts.Select(p => new ProductItemResponse(p.Id, p.Name, p.Price, p.Quantity)).ToList();

        return productsResponse;
    }
}
