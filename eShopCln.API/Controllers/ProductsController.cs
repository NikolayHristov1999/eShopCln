using AutoMapper;
using eShopCln.API.Abstractions;
using eShopCln.Application.Products.Commands.CreateProduct;
using eShopCln.Application.Products.Queries.GetProductById;
using eShopCln.Contracts.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopCln.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public class ProductsController : ApiController
{
    private readonly IMapper _mapper;

    public ProductsController(ISender sender, IMapper mapper)
        : base(sender)
    {
        _mapper = mapper;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var query = new GetProductByIdQuery(id);
        var product = await _sender.Send(query);

        if (product.IsFailure)
        {
            return HandleFailure(product);
        }

        return Ok(product.Value);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequest product)
    {
        var productCommand = _mapper.Map<CreateProductCommand>(product);

        var result = await _sender.Send(productCommand);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return CreatedAtAction(
            nameof(GetProductById),
            new { id = result.Value },
            result.Value);
    }
}
