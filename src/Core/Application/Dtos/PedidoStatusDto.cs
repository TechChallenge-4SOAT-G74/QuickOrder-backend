namespace QuickOrder.Core.Application.Dtos
{
    public class PedidoStatusDto
    {
        public string Id { get; set; }
        public int NumeroPedido { get; set; }
        public string StatusPedido { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
