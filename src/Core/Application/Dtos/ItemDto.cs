namespace QuickOrder.Core.Application.Dtos
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string? TipoItem { get; set; }
        public double Valor { get; set; }
        public int QuantidadeItem { get; set; }
    }
}
