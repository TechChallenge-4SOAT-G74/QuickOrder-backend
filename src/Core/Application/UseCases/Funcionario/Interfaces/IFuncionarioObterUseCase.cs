using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Funcionario.Interfaces
{
    public interface IFuncionarioObterUseCase : IBaseUseCase
    {
        Task<ServiceResult<List<FuncionarioDto>>> Execute();
        Task<ServiceResult<FuncionarioDto>> Execute(int id);
    }
}
