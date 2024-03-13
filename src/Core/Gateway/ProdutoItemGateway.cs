using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Gateway
{
    public class ProdutoItemGateway : Repository<ProdutoItem>, IProdutoItemGateway
    {
        public ProdutoItemGateway(ApplicationContext context) :
            base(context)
        {
        }

    }
}
