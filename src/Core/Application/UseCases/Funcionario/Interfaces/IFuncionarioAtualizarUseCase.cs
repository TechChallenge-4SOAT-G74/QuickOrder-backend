using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Funcionario.Interfaces
{
    public interface IFuncionarioAtualizarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(FuncionarioDto funcionario, int id);
    }
}
