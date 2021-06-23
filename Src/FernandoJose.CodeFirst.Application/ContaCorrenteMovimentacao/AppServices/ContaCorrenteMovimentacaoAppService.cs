using FernandoJose.CodeFirst.Application.ContaCorrenteMovimentacao.Interfaces;
using FernandoJose.CodeFirst.Application.ContaCorrenteMovimentacao.ViewModels;
using FernandoJose.CodeFirst.Application.Share.ViewModels;
using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Commands;
using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Interfaces.SqlServerRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Application.ContaCorrenteMovimentacao.AppServices
{
    public class ContaCorrenteMovimentacaoAppService : IContaCorrenteMovimentacaoAppService
    {
        private readonly IMediator _mediator;
        private readonly IContaCorrenteMovimentacaoSqlServerRepository _contaCorrenteMovimentacaoSqlServerRepository;

        public ContaCorrenteMovimentacaoAppService(IMediator mediator, IContaCorrenteMovimentacaoSqlServerRepository contaCorrenteMovimentacaoSqlServerRepository)
        {
            _mediator = mediator;
            _contaCorrenteMovimentacaoSqlServerRepository = contaCorrenteMovimentacaoSqlServerRepository;
        }

        public async Task<ResponseViewModel> AdicionarAsync(ContaCorrenteMovimentacaoAdicionarRequestViewModel request)
        {
            // TODO:: Fernando - Criar um controle de transação com UnitOfWork
            //-------------------------------------------------------------

            // Obter conta de
            var contaCorrenteDe = ObterPorContaCorrenteId(request.ContaCorrenteIdDe);
            if (contaCorrenteDe == null)
            {
                throw new Exception("Conta de não encontrada");
            }

            // Obter conta para
            var contaCorrentePara = ObterPorContaCorrenteId(request.ContaCorrenteIdPara);
            if (contaCorrentePara == null)
            {
                throw new Exception("Conta para não encontrada");
            }

            // Diminuir valor da conta de
            var contaCorrenteDeMovimentacaoAdicionarCommand = new ContaCorrenteMovimentacaoAdicionarCommand(request.ContaCorrenteIdDe, request.Valor, contaCorrenteDe.SaldoAtualizado - request.Valor, 1); // TODO:: Fernando - Criar um enum para o tipo
            await _mediator.Send(contaCorrenteDeMovimentacaoAdicionarCommand, CancellationToken.None).ConfigureAwait(true);

            // Somar valor da conta para
            var contaCorrenteParaMovimentacaoAdicionarCommand = new ContaCorrenteMovimentacaoAdicionarCommand(request.ContaCorrenteIdPara, request.Valor, contaCorrenteDe.SaldoAtualizado + request.Valor, 2); // TODO:: Fernando - Criar um enum para o tipo
            await _mediator.Send(contaCorrenteParaMovimentacaoAdicionarCommand, CancellationToken.None).ConfigureAwait(true);

            return new ResponseViewModel(true, new { SaldoAtualizadoDe = contaCorrenteDe.SaldoAtualizado, SaldoAtualizadoPara = contaCorrentePara.SaldoAtualizado });
        }

        public ResponseViewModel ObterSaldoAtualizado(int contaCorrenteId)
        {
            Domain.ContaCorrenteMovimentacao.Models.ContaCorrenteMovimentacao contaCorrenteMovimentacaoObterResponse = ObterPorContaCorrenteId(contaCorrenteId);
            return new ResponseViewModel(true, contaCorrenteMovimentacaoObterResponse);
        }

        public ResponseViewModel Listar()
        {
            List<Domain.ContaCorrenteMovimentacao.Models.ContaCorrenteMovimentacao> contaCorrenteMovimentacaoListarResponse = _contaCorrenteMovimentacaoSqlServerRepository.Listar(_ => true);
            return new ResponseViewModel(true, contaCorrenteMovimentacaoListarResponse);
        }

        private Domain.ContaCorrenteMovimentacao.Models.ContaCorrenteMovimentacao ObterPorContaCorrenteId(int contaCorrenteId)
        {
            return _contaCorrenteMovimentacaoSqlServerRepository.Obter(x => x.ContaCorrenteId == contaCorrenteId);
        }
    }
}
