using System.Text.RegularExpressions;

namespace QuickOrder.Core.Domain.ValueObjects
{
    public class TelefoneVo
    {
        protected TelefoneVo() { }
        public TelefoneVo(string ddd, string numero)
        {
            DDD = ddd;
            Numero = numero;

            Validar();
        }
        public string DDD { get; private set; }
        public string Numero { get; private set; }

        public override string ToString()
        {
            return $"({DDD}){Numero}";
        }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace($"({DDD}){Numero}"))
                throw new Exception("Número Telefone não foi informado!");

            string pattern = @"^(\+55)?[\s]?\(?(1[1-9]|2[12478]|3([1-5]|[7-8])|4[1-9]|5(1|[3-5])|6[1-9]|7[134579]|8[1-9]|9[1-9])?\)?[\s-]?(9?\d{4}[\s-]?\d{4})$";
            if (Regex.IsMatch($"({DDD}){Numero}", pattern, RegexOptions.IgnoreCase))
                throw new Exception("Número telefone formato inválido!");
        }
    }
}
