using QuickOrder.Core.Domain.Adapters.Base;
using QuickOrder.Core.Domain.Entities.Base;
using QuickOrder.Core.Domain.ValueObjects;

namespace QuickOrder.Core.Domain.Entities
{
    public class Cliente : EntityBase, IAggregateRoot
    {
        protected Cliente() { }

        public Cliente(string ddd, string numeroTelefone, DateTime? dataNascimento, Usuario usuario, List<Pedido> pedidos)
        {
            Telefone = new TelefoneVo(ddd, numeroTelefone);
            DataNascimento = dataNascimento;
            Usuario = usuario;
            Pedidos = pedidos;
        }

        public Cliente(string ddd, string numeroTelefone, DateTime? dataNascimento, Usuario usuario)
        {
            Telefone = new TelefoneVo(ddd, numeroTelefone);
            DataNascimento = dataNascimento;
            Usuario = usuario;
        }

        public virtual TelefoneVo Telefone { get; set; }
        public virtual DateTime? DataNascimento { get; set; }
        public virtual int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public List<Pedido>? Pedidos { get; set; }

    }
}
