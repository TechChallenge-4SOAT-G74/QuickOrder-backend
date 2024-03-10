using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Application.UseCases.Produto.Interfaces;
using QuickOrder.Core.Domain.Enums;
using QuickOrder.Core.Domain.Repositories;

namespace QuickOrder.Core.Application.UseCases.Produto
{
    public class ProdutoObterUseCase : ProdutoUseCase, IProdutoObterUseCase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoObterUseCase(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ServiceResult<List<ProdutoDto>>> Execute()
        {
            ServiceResult<List<ProdutoDto>> result = new();
            try
            {
                var produtos = await _produtoRepository.GetAll();

                var list = new List<ProdutoDto>();

                foreach (var produto in produtos)
                {
                    list.Add(new ProdutoDto
                    {
                        Categoria = ECategoriaExtensions.ToDescriptionString((ECategoria)produto.CategoriaId),
                        Nome = produto.Nome.Nome,
                        Descricao = produto.Descricao,
                        Preco = produto.Preco,
                        ProdutoItens = produto.ProdutoItens == null ? null : ProdutoItensDto(produto.ProdutoItens)
                    });
                }


                result.Data = list;
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }

        public async Task<ServiceResult<ProdutoDto>> Execute(int id)
        {
            ServiceResult<ProdutoDto> result = new();
            try
            {
                var produto = await _produtoRepository.GetFirst(id);
                result.Data = new ProdutoDto
                {
                    Categoria = ECategoriaExtensions.ToDescriptionString((ECategoria)produto.CategoriaId),
                    Nome = produto.Nome.Nome,
                    Descricao = produto.Descricao,
                    Preco = produto.Preco,
                    ProdutoItens = produto.ProdutoItens == null ? null : ProdutoItensDto(produto.ProdutoItens)

                };
            }
            catch (Exception ex) { result.AddError(ex.Message); }
            return result;
        }
    }
}
