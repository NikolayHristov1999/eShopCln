using eShopCln.API.Abstractions;
using eShopCln.Application.Products.Commands.CreateProduct;
using eShopCln.Contracts.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopCln.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ApiController
{
    public ProductsController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequest product)
    {
        var productCommand = new CreateProductCommand(
            Name: product.Name,
            Price: product.Price,
            ShortDescription: product.ShortDescription,
            Quantity: product.Quantity,
            Description: product.Description
        );

        var result = await _sender.Send(productCommand);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return Created(
            nameof(GetProductById),
            new { id = result.Value },
            result.Value);
    }
}
