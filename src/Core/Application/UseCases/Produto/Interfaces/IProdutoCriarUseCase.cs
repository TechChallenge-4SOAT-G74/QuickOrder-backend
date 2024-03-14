using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.Dtos.Base;

namespace QuickOrder.Core.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoCriarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(ProdutoDto produto);
    }
}
