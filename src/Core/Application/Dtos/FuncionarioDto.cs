namespace QuickOrder.Core.Application.Dtos
{
    public class FuncionarioDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public int Matricula { get; set; }
        public bool Status { get; set; }
        public string Role { get; set; }
    }
}