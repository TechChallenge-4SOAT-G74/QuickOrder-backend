using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.Dtos.Base;

namespace QuickOrder.Core.Application.UseCases.Funcionario.Interfaces
{
    public interface IFuncionarioAtualizarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(FuncionarioDto funcionario, int id);
    }
}
