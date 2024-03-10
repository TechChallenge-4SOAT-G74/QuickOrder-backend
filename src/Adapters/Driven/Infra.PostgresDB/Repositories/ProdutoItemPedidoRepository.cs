using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Adapters.Driven.PostgresDB.Repositories
{
    public class ProdutoItemPedidoRepository : Repository<ProdutoItemPedido>, IProdutoItemPedidoRepository
    {
        public ProdutoItemPedidoRepository(ApplicationContext context) : base(context)
        {
        }

    }
}
