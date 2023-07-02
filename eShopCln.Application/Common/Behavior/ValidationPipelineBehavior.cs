using eShopCln.Domain.Shared;
using FluentValidation;
using MediatR;

namespace eShopCln.Application.Common.Behavior;

public sealed class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationPipelineBehavior(IValidator<TRequest> validator)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(x => new Error(x.ErrorCode, x.ErrorMessage));

            return CreateValidationResult<TResponse>(errors);
        }

        return await next();
    }

    private static TResult CreateValidationResult<TResult>(IEnumerable<Error> errors)
        where TResult : Result
    {
        if (typeof(TResponse) == typeof(Result))
        {
            return (ValidationResult.WithErrors(errors) as TResult)!;
        }

        object validationResult = typeof(ValidationResult<>)
            .GetGenericTypeDefinition()
            .MakeGenericType(typeof(TResult).GetGenericArguments()[0])
            .GetMethod(nameof(ValidationResult<object>.WithErrors))!
            .Invoke(null, new object[] { errors })!;

        return (TResult)validationResult;
    }
}
