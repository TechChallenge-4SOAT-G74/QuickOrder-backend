using QuickOrder.Core.Application.Dtos;

namespace QuickOrder.Core.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoCriarUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(ProdutoDto produto);
    }
}
