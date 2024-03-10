using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Core.Domain.Repositories
{
    public interface IFuncionarioRepository : IBaseRepository, IRepository<Funcionario>
    {
    }
}
