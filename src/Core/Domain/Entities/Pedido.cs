namespace QuickOrder.Core.Domain.Entities
{
    public class Pedido : EntityBase, IAggregateRoot
    {
        protected Pedido() { }
        public Pedido(int numeroPedido,
                      DateTime dataHoraInicio,
                      DateTime? dataHoraFinalizado,
                      int? clienteId,
                      string? carrinhoId,
                      List<ProdutoItemPedido>? produtosItemsPedido,
                      double valorPedido,
                      bool pedidoPago,
                      string? observacao = null)
        {
            NumeroPedido = numeroPedido;
            DataHoraInicio = dataHoraInicio;
            DataHoraFinalizado = dataHoraFinalizado;
            ClienteId = clienteId;
            CarrinhoId = carrinhoId;
            ProdutosItemsPedido = produtosItemsPedido;
            ValorPedido = valorPedido;
            PedidoPago = pedidoPago;
            Observacao = observacao;

            CalculaPrecoPedido();
        }

        public virtual int NumeroPedido { get; set; }
        public virtual string? CarrinhoId { get; set; }
        public virtual DateTime DataHoraInicio { get; set; }
        public virtual DateTime? DataHoraFinalizado { get; set; }
        public virtual int? ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; }
        public virtual List<ProdutoItemPedido>? ProdutosItemsPedido { get; set; }
        public virtual double ValorPedido { get; set; }
        public virtual string? Observacao { get; set; }
        public virtual bool PedidoPago { get; set; }

        public double CalculaPrecoPedido()
        {
            if (this.ProdutosItemsPedido != null)
            {
                var quantidadeProduto = 0;
                var valorProduto = 0.0;
                var valorPedido = 0.0;

                foreach (var produto in this.ProdutosItemsPedido.ToList())
                {

                    quantidadeProduto += produto.QuantidadeProduto;
                    valorProduto += produto.ProdutoItem.Quantidade * produto.ProdutoItem.Item.Valor;

                    valorPedido += quantidadeProduto * valorProduto;
                }

                this.ValorPedido = this.ValorPedido < valorPedido ? valorPedido : this.ValorPedido;
            }

            return this.ValorPedido;
        }
    }
}
