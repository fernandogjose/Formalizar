using FernandoJose.CodeFirst.Application.ContaCorrenteMovimentacao.ViewModels;
using FernandoJose.CodeFirst.Application.Share.ViewModels;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Application.ContaCorrenteMovimentacao.Interfaces
{
    public interface IContaCorrenteMovimentacaoAppService
    {
        Task<ResponseViewModel> AdicionarAsync(ContaCorrenteMovimentacaoAdicionarRequestViewModel request);

        ResponseViewModel ObterSaldoAtualizado(int contaCorrenteId);

        ResponseViewModel Listar();
    }
}
