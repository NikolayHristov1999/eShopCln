using eShopCln.Application.Products.Commands.CreateProduct;
using eShopCln.Contracts.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopCln.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly ISender _mediator;

    public ProductsController(ISender mediator)
    {
        _mediator = mediator;
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

        var id = await _mediator.Send(productCommand);

        return Created(id.Value.ToString(), null);
    }
}
