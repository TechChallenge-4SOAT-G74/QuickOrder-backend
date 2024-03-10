using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.PostgresDB.Mapping
{
    public class ItemMap : IEntityMap<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.Property(x => x.TipoItem)
                  .IsRequired();
            builder.Property(x => x.Valor)
                .IsRequired();
            builder.Property(x => x.QuantidadeItem)
                .IsRequired();
            builder.HasMany(x => x.ProdutoItens);
        }
    }
}