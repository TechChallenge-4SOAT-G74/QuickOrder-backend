using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Gateway
{
    public class ProdutoGateway : Repository<Produto>, IProdutoGateway
    {
        public ProdutoGateway(ApplicationContext context) :
            base(context)
        {
        }

    }
}
