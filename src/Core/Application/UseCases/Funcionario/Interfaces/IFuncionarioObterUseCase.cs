using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.Dtos.Base;

namespace QuickOrder.Core.Application.UseCases.Funcionario.Interfaces
{
    public interface IFuncionarioObterUseCase : IBaseUseCase
    {
        Task<ServiceResult<List<FuncionarioDto>>> Execute();
        Task<ServiceResult<FuncionarioDto>> Execute(int id);
    }
}
