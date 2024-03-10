using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Core.Domain.Repositories
{
    public interface IPedidoRepository : IBaseRepository, IRepository<Pedido>
    {
        Task<List<Pedido>> ObterListaPedidos();
    }
}
