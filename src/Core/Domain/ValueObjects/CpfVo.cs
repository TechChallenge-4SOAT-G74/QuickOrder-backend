namespace QuickOrder.Core.Domain.ValueObjects
{
    public class CpfVo
    {
        protected CpfVo() { }
        public CpfVo(string codigoCpf)
        {
            CodigoCpf = codigoCpf;
            Validar();
        }
        public string CodigoCpf { get; private set; }
        public override string ToString()
        {
            return $"{CodigoCpf}";
        }

        private void Validar()
        {
            if (!VerificaCPF())
                throw new Exception("CPF Inválido! Não é possível criar Usuário");
        }

        public bool VerificaCPF()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            CodigoCpf = CodigoCpf.Trim();
            CodigoCpf = CodigoCpf.Replace(".", "").Replace("-", "");
            if (CodigoCpf.Length != 11)
            {
                return false;
            }

            tempCpf = CodigoCpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma % 11;
            if (resto < 2)
            {
                resto = 0;
            }
            else
            {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();
            return CodigoCpf.EndsWith(digito);
        }
    }
}
