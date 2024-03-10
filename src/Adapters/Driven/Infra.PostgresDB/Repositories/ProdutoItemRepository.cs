using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Adapters.Driven.PostgresDB.Repositories
{
    public class ProdutoItemRepository : Repository<ProdutoItem>, IProdutoItemRepository
    {
        public ProdutoItemRepository(ApplicationContext context) :
            base(context)
        {
        }

    }
}
