using System;

namespace FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Models
{
    public class ContaCorrenteMovimentacao
    {
        public int Id { get; set; }

        public int ContaCorrenteId { get; set; }

        public int ContaCorrenteMovimentacaoTipoId { get; set; }

        public decimal Valor { get; set; }

        public decimal SaldoAtualizado { get; set; }

        public DateTime CriadaEm { get; set; }

        public ContaCorrente.Models.ContaCorrente ContaCorrente { get; set; }

        public ContaCorrenteMovimentacaoTipo.Models.ContaCorrenteMovimentacaoTipo ContaCorrenteMovimentacaoTipo { get; set; }
    }
}
