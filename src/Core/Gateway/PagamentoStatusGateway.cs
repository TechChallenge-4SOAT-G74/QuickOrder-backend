using QuickOrder.Adapters.Driven.MongoDB.Core;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.MongoDB.Repositories
{
    public class PagamentoStatusGateway : BaseMongoDBRepository<PagamentoStatus>, IPagamentoStatusGateway
    {
        public PagamentoStatusGateway(IMondoDBContext mondoDBContext) : base(mondoDBContext)
        {
        }
    }
}
