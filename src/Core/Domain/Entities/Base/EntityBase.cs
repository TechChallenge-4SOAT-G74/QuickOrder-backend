using QuickOrder.Core.Domain.Adapters.Base;

namespace QuickOrder.Core.Domain.Entities.Base
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual int Id { get; set; }
    }
}
