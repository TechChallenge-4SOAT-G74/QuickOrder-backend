using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Gateway
{
    public class ItemGateway : Repository<Item>, IItemGateway
    {
        public ItemGateway(ApplicationContext context) :
            base(context)
        {
        }

    }
}
