using FernandoJose.CodeFirst.Domain.ContaCorrente.Models;
using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Models;
using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacaoTipo.Models;
using FernandoJose.CodeFirst.Domain.ContaCorrenteTipo.Models;
using FernandoJose.CodeFirst.SqlServer.Maps;
using Microsoft.EntityFrameworkCore;

namespace FernandoJose.CodeFirst.SqlServer.Contexts
{
    public class FernandoJoseCodeFirstDbContext : DbContext
    {
        public DbSet<ContaCorrente> ContaCorrentes { get; set; }

        public DbSet<ContaCorrenteTipo> ContaCorrenteTipos { get; set; }

        public DbSet<ContaCorrenteMovimentacao> ContaCorrenteMovimentacaos { get; set; }

        public DbSet<ContaCorrenteMovimentacaoTipo> ContaCorrenteMovimentacaoTipos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\ProjectsV13;Database=FernandoJoseCodeFirst;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaCorrenteMap());
        }
    }
}
