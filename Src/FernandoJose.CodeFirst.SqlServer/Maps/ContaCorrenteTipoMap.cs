using FernandoJose.CodeFirst.Domain.ContaCorrenteTipo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FernandoJose.CodeFirst.SqlServer.Maps
{
    public class ContaCorrenteTipoMap : IEntityTypeConfiguration<ContaCorrenteTipo>
    {
        public void Configure(EntityTypeBuilder<ContaCorrenteTipo> builder)
        {
            builder.ToTable("ContaCorrenteTipo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasMaxLength(100);
            builder.Property(x => x.Sigla).HasMaxLength(2);
        }
    }
}
