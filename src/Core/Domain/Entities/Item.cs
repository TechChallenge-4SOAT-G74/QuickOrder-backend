namespace QuickOrder.Core.Domain.Entities
{
    public class Item : EntityBase, IAggregateRoot
    {
        protected Item() { }
        public Item(int tipoItem, double valor, int quantidadeItem)
        {
            TipoItem = tipoItem;
            Valor = valor;
            QuantidadeItem = quantidadeItem;
        }

        public virtual int TipoItem { get; set; }
        public virtual double Valor { get; set; }
        public virtual int QuantidadeItem { get; set; }
        public virtual List<ProdutoItem>? ProdutoItens { get; set; }
    }
}
