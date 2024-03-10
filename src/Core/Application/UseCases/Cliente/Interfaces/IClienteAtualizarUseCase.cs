using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Cliente.Interfaces
{
    public interface IClienteAtualizarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(ClienteDto produto, int id);
    }
}
