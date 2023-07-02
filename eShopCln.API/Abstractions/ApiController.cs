using eShopCln.Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eShopCln.API.Abstractions;

public abstract class ApiController : ControllerBase
{
    protected readonly ISender _sender;

    protected ApiController(ISender sender)
    {
        _sender = sender;
    }

    protected IActionResult HandleFailure(Result result) => result switch
    {
        { IsSuccess: true } => throw new InvalidOperationException(),
        IValidationResult validationResult => 
            BadRequest(CreateProblemDetails(
                "ValidationError",
                StatusCodes.Status400BadRequest,
                result.Error,
                validationResult.Errors)),
        _ => 
            BadRequest(CreateProblemDetails(
                "Bad Request",
                StatusCodes.Status400BadRequest,
                result.Error))
    };

    private static ProblemDetails CreateProblemDetails(string title, int status, Error error, IEnumerable<Error>? errors = null)
    => new ProblemDetails()
    {
        Title = title,
        Type = error.Code,
        Detail = error.Message,
        Status = status,
        Extensions = { { nameof(errors), errors } }
    };
}
