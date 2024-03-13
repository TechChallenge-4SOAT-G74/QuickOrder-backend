using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Gateway
{
    public class ProdutoItemPedidoGateway : Repository<ProdutoItemPedido>, IProdutoItemPedidoGateway
    {
        public ProdutoItemPedidoGateway(ApplicationContext context) : base(context)
        {
        }

    }
}
