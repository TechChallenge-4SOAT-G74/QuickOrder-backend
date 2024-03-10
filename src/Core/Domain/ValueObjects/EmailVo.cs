using System.Text.RegularExpressions;

namespace QuickOrder.Core.Domain.ValueObjects
{
    public class EmailVo
    {
        public string Endereco { get; private set; }

        public EmailVo(string endereco)
        {
            Endereco = endereco;
            Validar();
        }

        protected EmailVo() { }

        private void Validar()
        {
            string pattern = @"/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i";
            if (Regex.IsMatch(Endereco, pattern, RegexOptions.IgnoreCase))
                throw new Exception("E-mail Inválido! Não é possível criar Usuário");
        }
    }
}
