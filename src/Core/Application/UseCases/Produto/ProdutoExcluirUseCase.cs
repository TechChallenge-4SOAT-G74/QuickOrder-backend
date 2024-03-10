using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Produto
{
    public class ProdutoExcluirUseCase : IProdutoExcluirUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoExcluirUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ServiceResult> Execute(int id)
        {
            ServiceResult result = new();
            try
            {
                var produtoExiste = await _produtoRepository.GetFirst(id);

                if (produtoExiste == null)
                {
                    result.AddError("Produto não encontrado.");
                    return result;
                }
                await _produtoRepository.Delete(id);
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}
