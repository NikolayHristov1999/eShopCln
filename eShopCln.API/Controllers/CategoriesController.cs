using AutoMapper;
using eShopCln.API.Abstractions;
using eShopCln.Application.Categories.Commands.CreateCategory;
using eShopCln.Application.Products.Commands.CreateProduct;
using eShopCln.Application.Products.Commands.UpdateProduct;
using eShopCln.Application.Products.Queries.GetProductById;
using eShopCln.Contracts.Categories;
using eShopCln.Contracts.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopCln.API.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
public sealed class CategoriesController : ApiController
{
    private readonly IMapper _mapper;

    public CategoriesController(ISender sender, IMapper mapper) : base(sender)
    {
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequest category)
    {
        var categoryCommand = _mapper.Map<CreateCategoryCommand>(category);

        var result = await _sender.Send(categoryCommand);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return CreatedAtAction(
            nameof(GetCategoryById),
            new { id = result.Value },
            result.Value);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var query = new GetProductByIdQuery(id);
        var product = await _sender.Send(query);

        if (product.IsFailure)
        {
            return HandleFailure(product);
        }

        return Ok(product.Value);
    }
}
