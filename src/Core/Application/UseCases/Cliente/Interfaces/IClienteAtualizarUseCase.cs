using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.Dtos.Base;

namespace QuickOrder.Core.Application.UseCases.Cliente.Interfaces
{
    public interface IClienteAtualizarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(ClienteDto produto, int id);
    }
}
