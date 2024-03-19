using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Gateway
{
    public class UsuarioGateway : Repository<Usuario>, IUsuarioGateway
    {
        public UsuarioGateway(ApplicationContext context) :
            base(context)
        {
        }

    }
}
