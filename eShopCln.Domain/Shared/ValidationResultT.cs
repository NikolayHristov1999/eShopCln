namespace eShopCln.Domain.Shared;

public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    private ValidationResult(IEnumerable<Error> errors)
        : base(default, false, IValidationResult.ValidationError)
    {
        Errors = errors;
    }

    public IEnumerable<Error> Errors { get; }

    public static ValidationResult<TValue> WithErrors(IEnumerable<Error> errors) => new(errors);
}
