using QuickOrder.Core.Domain.Adapters.Base;
using QuickOrder.Core.Domain.Entities.Base;

namespace QuickOrder.Core.Domain.Entities
{
    public class ProdutoItemPedido : EntityBase, IAggregateRoot
    {
        public ProdutoItemPedido()
        {
                
        }
        public ProdutoItemPedido(ProdutoItem? produtoItem, int? pedidoId)
        {
            ProdutoItem = produtoItem;
            PedidoId = pedidoId;
        }

        public virtual int? ProdutoItemId { get; set; }
        public virtual ProdutoItem? ProdutoItem { get; set; }
        public virtual int? PedidoId { get; set; }
        public virtual Pedido? Pedido { get; set; }
        public virtual int QuantidadeProduto { get; set; }
        public virtual List<Pedido>? Pedidos { get; set; }
    }
}