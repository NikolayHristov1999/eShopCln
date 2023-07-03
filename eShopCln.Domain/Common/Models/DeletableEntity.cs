using eShopCln.Domain.Common.Models.Interfaces;

namespace eShopCln.Domain.Common.Models
{
    public abstract class DeletableEntity : Entity, IDeletableEntity
    {
        protected DeletableEntity(Guid id) 
            : base(id)
        {
        }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOnUtc { get; set; }
    }
}
