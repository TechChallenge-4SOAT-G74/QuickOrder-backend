using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Gateway
{
    public class FuncionarioGateway : Repository<Funcionario>, IFuncionarioGateway
    {
        public FuncionarioGateway(ApplicationContext context) :
            base(context)
        {
        }

    }
}
