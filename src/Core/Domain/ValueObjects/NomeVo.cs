namespace QuickOrder.Core.Domain.ValueObjects
{
    public class NomeVo
    {

        public string Nome { get; private set; }

        public NomeVo(string nome)
        {
            Nome = nome;
            Validar();
        }

        protected NomeVo() { }

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nome)) { throw new Exception("Nome não informado!"); }
            if (Nome.Length < 3) { throw new Exception("Nome deve ter mais de 3 caracteres!"); }
            if (Nome.Length > 150) { throw new Exception("Nome deve ter máximo 150 caracteres"); }
        }

    }
}
