namespace QuickOrder.Core.Domain.Entities
{
    public class Funcionario : EntityBase, IAggregateRoot
    {
        protected Funcionario() { }
        public Funcionario(int matricula, Usuario usuario)
        {
            Matricula = matricula;
            Usuario = usuario;
        }

        public virtual int Matricula { get; set; }
        public virtual int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
