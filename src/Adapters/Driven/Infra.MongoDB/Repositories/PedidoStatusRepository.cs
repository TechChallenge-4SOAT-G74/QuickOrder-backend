using QuickOrder.Adapters.Driven.MongoDB.Core;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.MongoDB.Repositories
{
    public class PedidoStatusRepository : BaseMongoDBRepository<PedidoStatus>, IPedidoStatusRepository
    {
        public PedidoStatusRepository(IMondoDBContext mondoDBContext) : base(mondoDBContext)
        {
        }
    }
}
