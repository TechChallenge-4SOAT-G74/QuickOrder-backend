namespace QuickOrder.Core.Application.Dtos
{
    public class ProdutoItemPedidoDto
    {
        public virtual ProdutoItemDto ProdutoItem { get; set; }
        public virtual PedidoDto Pedido { get; set; }
        public virtual int QuantidadeProduto { get; set; }
        public virtual List<PedidoDto> Pedidos { get; set; }
    }
}
