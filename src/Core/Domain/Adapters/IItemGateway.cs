using QuickOrder.Core.Domain.Adapters.Base;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Core.Domain.Repositories
{
    public interface IItemGateway : IBaseRepository, IRepository<Item>
    {
    }
}
