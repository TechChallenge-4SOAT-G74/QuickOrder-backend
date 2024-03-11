using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.Dtos.Base;

namespace QuickOrder.Core.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoObterUseCase : IBaseUseCase
    {
        Task<ServiceResult<List<ProdutoDto>>> Execute();
        Task<ServiceResult<ProdutoDto>> Execute(int id);
    }
}
