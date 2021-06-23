using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacaoTipo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FernandoJose.CodeFirst.SqlServer.Maps
{
    public class ContaCorrenteMovimentacaoTipoMap : IEntityTypeConfiguration<ContaCorrenteMovimentacaoTipo>
    {
        public void Configure(EntityTypeBuilder<ContaCorrenteMovimentacaoTipo> builder)
        {
            builder.ToTable("ContaCorrenteMovimentacaoTipo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).HasMaxLength(100);
            builder.Property(x => x.Sigla).HasMaxLength(2);
        }
    }
}
