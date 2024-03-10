namespace QuickOrder.Core.Application.Dtos
{
    public class ClienteDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool Status { get; set; }
    }
}