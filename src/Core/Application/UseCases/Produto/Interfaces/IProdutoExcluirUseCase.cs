using QuickOrder.Core.Application.Dtos.Base;

namespace QuickOrder.Core.Application.UseCases.Produto.Interfaces
{
    public interface IProdutoExcluirUseCase : IBaseUseCase
    {
        Task<ServiceResult> Execute(int id);
    }
}
