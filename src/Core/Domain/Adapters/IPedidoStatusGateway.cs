using QuickOrder.Core.Domain.Adapters.Base;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Core.Domain.Adapters
{
    public interface IPedidoStatusGateway : IBaseRepository, IBaseMongoDBRepository<PedidoStatus>
    {
    }
}
