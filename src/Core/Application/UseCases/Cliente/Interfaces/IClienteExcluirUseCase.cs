using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Cliente.Interfaces
{
    public interface IClienteExcluirUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(int id);
    }
}
