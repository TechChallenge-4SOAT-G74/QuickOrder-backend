using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Funcionario.Interfaces
{
    public interface IFuncionarioExcluirUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(int id);
    }
}
