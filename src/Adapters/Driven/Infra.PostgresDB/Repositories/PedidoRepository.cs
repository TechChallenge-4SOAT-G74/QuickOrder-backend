using Microsoft.EntityFrameworkCore;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Adapters.Driven.PostgresDB.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApplicationContext context) :
            base(context)
        {
        }

        public async Task<List<Pedido>> ObterListaPedidos()
        {
            var result = await Queryable()
              .Include(x => x.ProdutosItemsPedido)
              .ThenInclude(z => z.ProdutoItem)
              .ThenInclude(y => y.Produto)
              .ToListAsync();
            return result;
        }
    }
}
