using QuickOrder.Adapters.Driven.MongoDB.Core;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.MongoDB.Repositories
{
    public class CarrinhoRepository : BaseMongoDBRepository<Carrinho>, ICarrinhoRepository
    {
        public CarrinhoRepository(IMondoDBContext mondoDBContext) : base(mondoDBContext)
        {
        }
    }
}
