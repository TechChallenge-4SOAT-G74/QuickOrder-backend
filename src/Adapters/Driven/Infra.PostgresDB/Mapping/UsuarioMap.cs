using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.PostgresDB.Mapping
{
    public class UsuarioMap : IEntityMap<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.OwnsOne(x => x.Nome, nome =>
            {
                nome.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(150)")
                .IsRequired(true);
            });

            builder.OwnsOne(c => c.Cpf, cpf =>
            {
                cpf.Property(x => x.CodigoCpf)
               .HasColumnName("Cpf")
               .HasColumnType("varchar(11)")
               .IsRequired(true);
            });


            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(x => x.Endereco)
                .HasColumnName("Email")
                .IsRequired(true);
            });

            builder.Property(x => x.Status)
                  .IsRequired();

            builder.Property(x => x.Role)
                 .IsRequired();
            builder.HasMany(x => x.Clientes);
            builder.HasMany(x => x.Funcionarios);
        }
    }
}

