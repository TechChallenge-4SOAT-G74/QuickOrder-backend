using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Cliente.Interfaces
{
    public interface IClienteObterUseCase : IBaseUseCase
    {
        Task<ServiceResult<List<ClienteDto>>> Execute();
        Task<ServiceResult<ClienteDto>> Execute(int id);
    }
}
