using QuickOrder.Core.Application.Dtos;
using QuickOrder.Core.Domain.Entities;
using QuickOrder.Core.Domain.Enums;

namespace QuickOrder.Core.Application.UseCases.Produto
{
    public abstract class ProdutoUseCase
    {
        protected static List<ProdutoItem> ProdutoItens(List<ProdutoItemDto> dto, int produtoId)
        {
            var produtoitens = new List<ProdutoItem>();
            foreach (var item in dto)
            {
                produtoitens.Add(new ProdutoItem(
                    produtoId,
                    item.Item.Id,
                    item.Quantidade,
                    item.QuantidadeMin,
                    item.QuantidadeMax,
                    item.PermitidoAlterar));
            }

            return produtoitens;
        }

        protected static List<ProdutoItemDto> ProdutoItensDto(List<ProdutoItem> obj)
        {
            var produtoitensDto = new List<ProdutoItemDto>();
            foreach (var item in obj)
            {
                produtoitensDto.Add(new ProdutoItemDto
                {
                    Item = new ItemDto()
                    {
                        TipoItem = ETipoItemExtensions.ToDescriptionString((ETipoItem)item.Item.TipoItem),
                        QuantidadeItem = (int)item.Item.QuantidadeItem,
                        Valor = item.Item.Valor
                    },
                    Quantidade = item.Quantidade,
                    QuantidadeMin = item.QuantidadeMin,
                    QuantidadeMax = item.QuantidadeMax,
                    PermitidoAlterar = item.PermitidoAlterar
                });
            }

            return produtoitensDto;
        }
    }
}
