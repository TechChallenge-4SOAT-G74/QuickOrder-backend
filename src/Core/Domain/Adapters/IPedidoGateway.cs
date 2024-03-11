using QuickOrder.Core.Domain.Adapters.Base;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Core.Domain.Repositories
{
    public interface IPedidoGateway : IBaseRepository, IRepository<Pedido>
    {
        Task<List<Pedido>> ObterListaPedidos();
    }
}
