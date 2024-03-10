using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;
using QuickOrder.Core.Domain.ValueObjects;

namespace QuickOrder.Core.Application.UseCases.Produto
{
    public class ProdutoAtualizarUseCase : ProdutoUseCase, IProdutoAtualizarUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoItemRepository _produtoItemRepository;

        public ProdutoAtualizarUseCase(IProdutoRepository produtoRepository, IProdutoItemRepository produtoItemRepository)
        {
            _produtoRepository = produtoRepository;
            _produtoItemRepository = produtoItemRepository;
        }

        public async Task<ServiceResult> Execute(ProdutoDto produtoViewModel, int id)
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

                produtoExiste.Nome = new NomeVo(produtoViewModel.Nome);
                produtoExiste.CategoriaId = (int)(ECategoria)Enum.Parse(typeof(ECategoria), produtoViewModel.Categoria);
                produtoExiste.Preco = produtoViewModel.Preco;
                produtoExiste.Descricao = produtoViewModel.Descricao ?? null;
                produtoExiste.Foto = produtoViewModel.Foto ?? null;

                await _produtoRepository.Update(produtoExiste);

                if (produtoViewModel.ProdutoItens != null)
                {
                    var produtoItens = ProdutoItens(produtoViewModel.ProdutoItens, produtoExiste.Id);

                    await _produtoItemRepository.Insert(produtoItens);
                }

            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }


    }
}
