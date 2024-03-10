namespace QuickOrder.Core.Domain.Entities
{
    public class PedidoStatus : EntityMongoBase
    {
        public PedidoStatus(int numeroPedido, string statusPedido, DateTime dataAtualizacao)
        {
            NumeroPedido = numeroPedido;
            StatusPedido = statusPedido;
            DataAtualizacao = dataAtualizacao;
        }

        public int NumeroPedido { get; set; }
        public string StatusPedido { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int StatusOrdem { get; set; }
    }
}
