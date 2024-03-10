namespace QuickOrder.Core.Application.Dtos
{
    public class ProdutoItemDto
    {
        public ItemDto Item { get; set; }
        public int Quantidade { get; set; }
        public int QuantidadeMin { get; set; }
        public int QuantidadeMax { get; set; }
        public bool PermitidoAlterar { get; set; }
    }
}
