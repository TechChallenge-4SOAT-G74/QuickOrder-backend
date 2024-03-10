using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.PostgresDB.Mapping
{
    public class PedidoMap : IEntityMap<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.Property(x => x.NumeroPedido)
                  .IsRequired();
            builder.Property(x => x.DataHoraInicio)
                 .IsRequired();
            builder.Property(x => x.DataHoraFinalizado)
                 .IsRequired(false);
            builder.Property(x => x.ClienteId)
               .HasColumnName("Cliente")
               .IsRequired(false);
            builder.Property(x => x.CarrinhoId)
                 .IsRequired(false);
            builder.HasMany(x => x.ProdutosItemsPedido);
            builder.Property(x => x.ValorPedido)
                 .IsRequired();
            builder.Property(x => x.Observacao)
                 .IsRequired(false);
            builder.Property(x => x.PedidoPago)
                 .IsRequired();
        }
    }
}