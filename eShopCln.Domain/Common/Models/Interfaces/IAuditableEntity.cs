namespace eShopCln.Domain.Common.Models.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime CreatedOnUtc { get; }

        DateTime? LastModifiedOnUtc { get; }
    }
}
