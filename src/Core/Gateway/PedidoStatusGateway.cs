using QuickOrder.Adapters.Driven.MongoDB.Core;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.MongoDB.Repositories
{
    public class PedidoStatusGateway : BaseMongoDBRepository<PedidoStatus>, IPedidoStatusGateway
    {
        public PedidoStatusGateway(IMondoDBContext mondoDBContext) : base(mondoDBContext)
        {
        }
    }
}
