using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Domain.Adapters
{
    public interface IPagamentoStatusRepository : IBaseRepository, IBaseMongoDBRepository<PagamentoStatus>
    {
    }
}
