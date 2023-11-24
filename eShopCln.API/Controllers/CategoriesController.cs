using AutoMapper;
using eShopCln.API.Abstractions;
using eShopCln.Application.Categories.Commands.CreateCategory;
using eShopCln.Application.Categories.Commands.DeleteCategory;
using eShopCln.Application.Categories.Commands.UpdateCategory;
using eShopCln.Application.Categories.Queries.GetCategories;
using eShopCln.Application.Categories.Queries.GetCategoryById;
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
        var query = new GetCategoryByIdQuery(id);
        var category = await _sender.Send(query);

        if (category.IsFailure)
        {
            return HandleFailure(category);
        }

        return Ok(category.Value);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCategory(Guid id, UpdateCategoryRequest categoryRequest)
    {
        var updateCategoryCommand = _mapper.Map<UpdateCategoryCommand>(categoryRequest);
        updateCategoryCommand.Id = id;

        var category = await _sender.Send(updateCategoryCommand);

        if (category.IsFailure)
        {
            return HandleFailure(category);
        }

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var deleteCategoryCommand = new DeleteCategoryCommand(id);

        var result = await _sender.Send(deleteCategoryCommand);

        if (result.IsFailure)
        {
            return HandleFailure(result);
        }

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var query = new GetCategoriesQuery(); // Assuming you have a GetAllCategoriesQuery class
        var categories = await _sender.Send(query);

        if (categories.IsFailure)
        {
            return HandleFailure(categories);
        }

        return Ok(categories.Value);
    }
}
