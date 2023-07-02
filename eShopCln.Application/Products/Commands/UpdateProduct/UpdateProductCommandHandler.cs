using eShopCln.Domain.Common.Repositories;
using eShopCln.Domain.Products;
using eShopCln.Domain.Shared;
using MediatR;

namespace eShopCln.Application.Products.Commands.UpdateProduct;

public sealed class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result>
{
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var dbProduct = _productRepository.GetByIdAsync(request.Id).Result;

        if (dbProduct is null)
        {
            return Result.Failure(new Error(
                "Item.NotFound",
                $"Product with id {request.Id} not found"));
        }

        dbProduct.Update(
            request.Name,
            request.ShortDescription,
            description: request.Description,
            price: request.Price,
            quantity: request.Quantity);

        await _productRepository.UpdateAsync(dbProduct);

        return Result.Success();
    }
}
