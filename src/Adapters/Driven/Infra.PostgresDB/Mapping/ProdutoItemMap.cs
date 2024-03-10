using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.PostgresDB.Mapping
{
    public class ProdutoItemMap : IEntityMap<ProdutoItem>
    {
        public void Configure(EntityTypeBuilder<ProdutoItem> builder)
        {
            builder.Property(x => x.ProdutoId)
                   .HasColumnName("Produto")
                   .IsRequired();
            builder.HasOne(x => x.Produto)
                .WithMany(x => x.ProdutoItens);
            builder.Property(x => x.ItemId)
                   .HasColumnName("Item");
            builder.HasOne(x => x.Item)
                .WithMany(x => x.ProdutoItens);
            builder.Property(x => x.Quantidade)
                  .IsRequired();
            builder.Property(x => x.QuantidadeMin)
                 .IsRequired();
            builder.Property(x => x.QuantidadeMax)
                 .IsRequired();
            builder.Property(x => x.PermitidoAlterar)
                 .IsRequired();
            builder.HasMany(x => x.ProdutosItemsPedido);
        }
    }
}