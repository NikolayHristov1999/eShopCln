using eShopCln.Domain.Common.Models;

namespace eShopCln.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    private Rating(double value)
    {
        Value = value;
    }

    public double Value { get; private set; }

    public static Rating CreateNew(double value)
    => new(value);

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
