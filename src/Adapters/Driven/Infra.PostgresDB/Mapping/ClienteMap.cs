using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.PostgresDB.Mapping
{
    public class ClienteMap : IEntityMap<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.OwnsOne(x => x.Telefone, telefone =>
            {
                telefone.Property(x => x.DDD)
                .HasColumnName("DDD")
                .HasColumnType("varchar(15)")
                .IsRequired(true);

                telefone.Property(x => x.Numero)
               .HasColumnName("Telefone")
               .HasColumnType("varchar(15)")
               .IsRequired(true);
            });
            builder.Property(x => x.DataNascimento)
                  .IsRequired(false);
            builder.Property(x => x.UsuarioId)
                .HasColumnName("Usuario")
                .IsRequired();
            builder.HasMany(x => x.Pedidos);
        }
    }
}
