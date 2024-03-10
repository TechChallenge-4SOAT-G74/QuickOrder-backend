using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickOrder.Adapters.Driven.PostgresDB.Core;
using QuickOrder.Core.Domain.Entities;

namespace QuickOrder.Adapters.Driven.PostgresDB.Mapping
{
    public class FuncionarioMap : IEntityMap<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.Property(x => x.Matricula)
                  .IsRequired(true);
            builder.Property(x => x.UsuarioId)
                .HasColumnName("Usuario")
                .IsRequired();
        }
    }
}