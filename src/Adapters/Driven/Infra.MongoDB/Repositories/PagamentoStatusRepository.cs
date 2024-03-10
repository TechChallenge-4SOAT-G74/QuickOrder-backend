using QuickOrder.Adapters.Driven.MongoDB.Core;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.MongoDB.Repositories
{
    public class PagamentoStatusRepository : BaseMongoDBRepository<PagamentoStatus>, IPagamentoStatusRepository
    {
        public PagamentoStatusRepository(IMondoDBContext mondoDBContext) : base(mondoDBContext)
        {
        }
    }
}
