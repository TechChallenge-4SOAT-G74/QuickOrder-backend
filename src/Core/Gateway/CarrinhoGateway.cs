using QuickOrder.Adapters.Driven.MongoDB.Core;
using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.MongoDB.Repositories
{
    public class CarrinhoGateway : BaseMongoDBRepository<Carrinho>, ICarrinhoGateway
    {
        public CarrinhoGateway(IMondoDBContext mondoDBContext) : base(mondoDBContext)
        {
        }
    }
}
