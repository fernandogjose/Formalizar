using FernandoJose.CodeFirst.Application.ContaCorrente.Interfaces;
using FernandoJose.CodeFirst.Application.ContaCorrente.ViewModels;
using FernandoJose.CodeFirst.Application.Share.ViewModels;
using FernandoJose.CodeFirst.Domain.ContaCorrente.Commands;
using FernandoJose.CodeFirst.Domain.ContaCorrente.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.Share.Commands;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Application.ContaCorrente.AppServices
{
    public class ContaCorrenteAppService : IContaCorrenteAppService
    {
        private readonly IMediator _mediator;
        private readonly IContaCorrenteSqlServerRepository _contaCorrenteSqlServerRepository;

        public ContaCorrenteAppService(IMediator mediator, IContaCorrenteSqlServerRepository contaCorrenteSqlServerRepository)
        {
            _mediator = mediator;
            _contaCorrenteSqlServerRepository = contaCorrenteSqlServerRepository;
        }

        public async Task<ResponseViewModel> AdicionarAsync(ContaCorrenteAdicionarRequestViewModel request)
        {
            ContaCorrenteAdicionarCommand contaCorrenteAdicionarCommand = new ContaCorrenteAdicionarCommand(request.Agencia, request.Conta, request.ContaCorrenteTipoId);
            ResponseCommand contaCorrenteAdicionarResponse = await _mediator.Send(contaCorrenteAdicionarCommand, CancellationToken.None).ConfigureAwait(true);
            return new ResponseViewModel(true, contaCorrenteAdicionarResponse);
        }

        public ResponseViewModel Obter(int id)
        {
            Domain.ContaCorrente.Models.ContaCorrente contaCorrenteObterResponse = _contaCorrenteSqlServerRepository.Obter(x => x.Id == id);
            return new ResponseViewModel(true, contaCorrenteObterResponse);
        }

        public ResponseViewModel ObterPorAgenciaConta(string agencia, string conta)
        {
            Domain.ContaCorrente.Models.ContaCorrente contaCorrenteObterResponse = _contaCorrenteSqlServerRepository.Obter(x => x.Agencia == agencia && x.Conta == conta);
            return new ResponseViewModel(true, contaCorrenteObterResponse);
        }

        public ResponseViewModel Listar()
        {
            List<Domain.ContaCorrente.Models.ContaCorrente> contaCorrenteListarResponse = _contaCorrenteSqlServerRepository.Listar(_ => true);
            return new ResponseViewModel(true, contaCorrenteListarResponse);
        }
    }
}
