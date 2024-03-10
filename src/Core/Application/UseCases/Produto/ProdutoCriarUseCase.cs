using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;
using ProdutoEntity = QuickOrder.Core.Domain.Entities.Produto;

namespace QuickOrder.Core.Application.UseCases.Produto
{
    public class ProdutoCriarUseCase : ProdutoUseCase, IProdutoCriarUseCase
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoItemRepository _produtoItemRepository;

        public ProdutoCriarUseCase(IProdutoRepository produtoRepository, IProdutoItemRepository produtoItemRepository)
        {
            _produtoRepository = produtoRepository;
            _produtoItemRepository = produtoItemRepository;
        }

        public async Task<ServiceResult> Execute(ProdutoDto produtoViewModel)
        {
            ServiceResult result = new();
            try
            {
                var produtoExiste = await _produtoRepository.GetFirst(x => x.Nome.Nome.Equals(produtoViewModel.Nome));
                if (produtoExiste != null)
                {
                    result.AddError("Produto já existe.");
                    return result;
                }

                var produto = new ProdutoEntity(
                    produtoViewModel.Nome,
                    (int)(ECategoria)Enum.Parse(typeof(ECategoria), produtoViewModel.Categoria),
                    produtoViewModel.Preco,
                    produtoViewModel.Descricao,
                    produtoViewModel.Foto
                    );

                var produtoInsert = await _produtoRepository.Insert(produto);

                if (produtoViewModel.ProdutoItens != null)
                {
                    var produtoItens = ProdutoItens(produtoViewModel.ProdutoItens, produtoInsert.Id);

                    await _produtoItemRepository.Insert(produtoItens);
                }

            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }

    }
}