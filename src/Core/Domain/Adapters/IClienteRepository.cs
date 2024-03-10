using QuickOrder.Core.Domain.Adapters;
using QuickOrder.Core.Domain.Entities;
using System.Linq.Expressions;

namespace QuickOrder.Core.Domain.Repositories
{
    public interface IClienteRepository : IBaseRepository, IRepository<Cliente>
    {
        Task<List<Cliente>> GetAllClienteComUsuario(Expression<Func<Cliente, bool>> predicate);
        Task<Cliente> GetClienteById(int id);
        Task<Cliente> GetClienteByCpfOrEmail(string cpf, string email);
    }
}
