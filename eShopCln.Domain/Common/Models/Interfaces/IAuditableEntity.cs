namespace eShopCln.Domain.Common.Models.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime CreatedOn { get; }

        DateTime? LastModifiedOn { get; }
    }
}
