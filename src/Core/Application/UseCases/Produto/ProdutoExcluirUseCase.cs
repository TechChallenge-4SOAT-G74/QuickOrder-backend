using QuickOrder.Core.Application.Dtos.Base;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Produto
{
    public class ProdutoExcluirUseCase : IProdutoExcluirUseCase
    {
        private readonly IProdutoGateway _produtoGateway;

        public ProdutoExcluirUseCase(IProdutoGateway produtoGateway)
        {
            _produtoGateway = produtoGateway;
        }

        public async Task<ServiceResult> Execute(int id)
        {
            ServiceResult result = new();
            try
            {
                var produtoExiste = await _produtoGateway.GetFirst(id);

                if (produtoExiste == null)
                {
                    result.AddError("Produto não encontrado.");
                    return result;
                }
                await _produtoGateway.Delete(id);
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}
