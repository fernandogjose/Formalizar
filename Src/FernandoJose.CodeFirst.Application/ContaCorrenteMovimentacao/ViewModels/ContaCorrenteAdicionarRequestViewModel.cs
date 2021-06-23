namespace FernandoJose.CodeFirst.Application.ContaCorrenteMovimentacao.ViewModels
{
    public class ContaCorrenteMovimentacaoAdicionarRequestViewModel
    {
        public decimal Valor { get; set; }

        public int ContaCorrenteIdDe { get; set; }

        public int ContaCorrenteIdPara { get; set; }
    }
}
