using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.Dtos.Base;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;
using ProdutoEntity = QuickOrder.Core.Domain.Entities.Produto;

namespace QuickOrder.Core.Application.UseCases.Produto
{
    public class ProdutoCriarUseCase : ProdutoUseCase, IProdutoCriarUseCase
    {
        private readonly IProdutoGateway _produtoGateway;
        private readonly IProdutoItemGateway _produtoItemGateway;

        public ProdutoCriarUseCase(IProdutoGateway produtoGateway, IProdutoItemGateway produtoItemGateway)
        {
            _produtoGateway = produtoGateway;
            _produtoItemGateway = produtoItemGateway;
        }

        public async Task<ServiceResult> Execute(ProdutoDto produtoViewModel)
        {
            ServiceResult result = new();
            try
            {
                var produtoExiste = await _produtoGateway.GetFirst(x => x.Nome.Nome.Equals(produtoViewModel.Nome));
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

                var produtoInsert = await _produtoGateway.Insert(produto);

                if (produtoViewModel.ProdutoItens != null)
                {
                    var produtoItens = ProdutoItens(produtoViewModel.ProdutoItens, produtoInsert.Id);

                    await _produtoItemGateway.Insert(produtoItens);
                }

            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }

    }
}