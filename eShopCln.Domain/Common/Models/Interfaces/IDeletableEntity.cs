namespace eShopCln.Domain.Common.Models.Interfaces
{
    public interface IDeletableEntity
    {
        public bool IsDeleted { get; }

        public DateTime? DeletedOnUtc { get;  }
    }
}
