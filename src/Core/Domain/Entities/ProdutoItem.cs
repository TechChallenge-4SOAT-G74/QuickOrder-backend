using QuickOrder.Core.Domain.Adapters.Base;
using QuickOrder.Core.Domain.Entities.Base;

namespace QuickOrder.Core.Domain.Entities
{
    public class ProdutoItem : EntityBase, IAggregateRoot
    {
        public ProdutoItem()
        {

        }
        public ProdutoItem(int produtoId, int quantidade)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
        }

        public ProdutoItem(int produtoId, int itemId, int quantidade, int quantidadeMin, int quantidadeMax, bool permitidoAlterar)
        {
            ProdutoId = produtoId;
            ItemId = itemId;
            Quantidade = quantidade;
            QuantidadeMin = quantidadeMin;
            QuantidadeMax = quantidadeMax;
            PermitidoAlterar = permitidoAlterar;
        }

        public virtual int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public virtual int? ItemId { get; set; }
        public virtual Item? Item { get; set; }
        public virtual int Quantidade { get; set; }
        public virtual int QuantidadeMin { get; set; }
        public virtual int QuantidadeMax { get; set; }
        public virtual bool PermitidoAlterar { get; set; }
        public virtual List<ProdutoItemPedido>? ProdutosItemsPedido { get; set; }
    }
}
