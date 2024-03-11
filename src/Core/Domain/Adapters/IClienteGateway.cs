using QuickOrder.Core.Domain.Adapters.Base;
using QuickOrder.Core.Domain.Entities;
using System.Linq.Expressions;

namespace QuickOrder.Core.Domain.Repositories
{
    public interface IClienteGateway : IBaseRepository, IRepository<Cliente>
    {
        Task<List<Cliente>> GetAllClienteComUsuario(Expression<Func<Cliente, bool>> predicate);
        Task<Cliente> GetClienteById(int id);
        Task<Cliente> GetClienteByCpfOrEmail(string cpf, string email);
    }
}
