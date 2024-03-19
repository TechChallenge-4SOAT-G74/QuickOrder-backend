using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.Dtos.Base;

namespace QuickOrder.Core.Application.UseCases.Funcionario.Interfaces
{
    public interface IFuncionarioCriarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(FuncionarioDto produto);
    }
}
