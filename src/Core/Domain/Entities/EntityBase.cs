namespace QuickOrder.Core.Domain.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual int Id { get; set; }
    }
}
