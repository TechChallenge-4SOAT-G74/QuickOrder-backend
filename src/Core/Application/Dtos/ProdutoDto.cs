namespace QuickOrder.Core.Application.Dtos
{
    public class ProdutoDto
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }

        public double Preco { get; set; }
        public string? Descricao { get; set; }
        public string? Foto { get; set; }
        public List<ProdutoItemDto>? ProdutoItens { get; set; }

    }
}
