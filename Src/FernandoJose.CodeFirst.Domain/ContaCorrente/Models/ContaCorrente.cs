using System;
using System.Collections.ObjectModel;

namespace FernandoJose.CodeFirst.Domain.ContaCorrente.Models
{
    public class ContaCorrente
    {
        public  int Id { get; set; }

        public int ContaCorrenteTipoId { get; set; }

        public string Agencia { get; set; }

        public string Conta { get; set; }

        public DateTime CriadaEm { get; set; }

        public Collection<ContaCorrenteMovimentacao.Models.ContaCorrenteMovimentacao> ContaCorrenteMovimentacaos { get; set; }

        public ContaCorrenteTipo.Models.ContaCorrenteTipo ContaCorrenteTipo { get; set; }
    }
}
