using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.PostgresDB.Mapping
{
    public class ProdutoItemPedidoMap : IEntityMap<ProdutoItemPedido>
    {
        public void Configure(EntityTypeBuilder<ProdutoItemPedido> builder)
        {
            builder.Property(x => x.ProdutoItemId)
                   .HasColumnName("PordutoItem")
                   .IsRequired();
            builder.HasOne(x => x.ProdutoItem)
             .WithMany(x => x.ProdutosItemsPedido);
            builder.Property(x => x.PedidoId)
                   .HasColumnName("Pedido")
                   .IsRequired();
            builder.HasOne(x => x.Pedido)
                .WithMany(x => x.ProdutosItemsPedido);
            builder.Property(x => x.QuantidadeProduto)
                  .IsRequired();
            builder.HasMany(x => x.Pedidos);
        }
    }
}
