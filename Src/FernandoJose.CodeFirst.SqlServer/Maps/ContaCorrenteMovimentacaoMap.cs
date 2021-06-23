using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FernandoJose.CodeFirst.SqlServer.Maps
{
    public class ContaCorrenteMovimentacaoMap : IEntityTypeConfiguration<ContaCorrenteMovimentacao>
    {
        public void Configure(EntityTypeBuilder<ContaCorrenteMovimentacao> builder)
        {
            builder.ToTable("ContaCorrente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ContaCorrenteId);
            builder.Property(x => x.ContaCorrenteMovimentacaoTipoId);
            builder.Property(x => x.Valor);
            builder.Property(x => x.SaldoAtualizado);
            builder.Property(x => x.CriadaEm);

            builder.HasOne(e => e.ContaCorrente).WithMany(e => e.ContaCorrenteMovimentacaos).HasForeignKey(e => e.ContaCorrenteId);
            builder.HasOne(e => e.ContaCorrenteMovimentacaoTipo).WithMany(e => e.ContaCorrenteMovimentacaos).HasForeignKey(e => e.ContaCorrenteMovimentacaoTipoId);
        }
    }
}
