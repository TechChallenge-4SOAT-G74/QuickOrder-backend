using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Funcionario.Interfaces
{
    public interface IFuncionarioCriarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(FuncionarioDto produto);
    }
}
