using FernandoJose.CodeFirst.Application.ContaCorrente.ViewModels;
using FernandoJose.CodeFirst.Application.Share.ViewModels;
using System;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Application.ContaCorrente.Interfaces
{
    public interface IContaCorrenteAppService
    {
        Task<ResponseViewModel> AdicionarAsync(ContaCorrenteAdicionarRequestViewModel request);

        ResponseViewModel Obter(int id);

        ResponseViewModel ObterPorAgenciaConta(string agencia, string conta);

        ResponseViewModel Listar();
    }
}
