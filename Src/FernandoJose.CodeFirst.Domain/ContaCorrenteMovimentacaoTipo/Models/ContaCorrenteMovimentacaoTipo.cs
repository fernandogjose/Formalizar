using System.Collections.ObjectModel;

namespace FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacaoTipo.Models
{
    public class ContaCorrenteMovimentacaoTipo
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public string Sigla { get; set; }

        public Collection<ContaCorrenteMovimentacao.Models.ContaCorrenteMovimentacao> ContaCorrenteMovimentacaos { get; set; }
    }
}
