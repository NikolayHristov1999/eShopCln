namespace eShopCln.Domain.Common.Models
{
    public abstract class DeletableAggregateRoot : DeletableEntity
    {
        protected DeletableAggregateRoot(Guid id)
            : base(id)
        {
        }
    }
}
