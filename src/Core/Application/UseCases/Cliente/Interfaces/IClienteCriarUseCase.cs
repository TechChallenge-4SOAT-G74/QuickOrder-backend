using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Cliente.Interfaces
{
    public interface IClienteCriarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(ClienteDto produto);
    }
}
