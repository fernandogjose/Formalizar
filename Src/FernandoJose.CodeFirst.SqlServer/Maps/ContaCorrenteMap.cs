using FernandoJose.CodeFirst.Domain.ContaCorrente.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FernandoJose.CodeFirst.SqlServer.Maps
{
    public class ContaCorrenteMap : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.ToTable("ContaCorrente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Agencia).HasMaxLength(10);
            builder.Property(x => x.Conta).HasMaxLength(10);
            builder.Property(x => x.CriadaEm);

            builder.HasOne(e => e.ContaCorrenteTipo).WithMany(e => e.ContaCorrentes).HasForeignKey(e => e.ContaCorrenteTipoId);
        }
    }
}
