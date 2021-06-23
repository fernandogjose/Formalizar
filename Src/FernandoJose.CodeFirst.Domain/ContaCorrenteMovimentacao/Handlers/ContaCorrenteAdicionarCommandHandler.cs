using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Commands;
using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.Share.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Handlers
{
    public class ContaCorrenteMovimentacaoAdicionarCommandHandler : IRequestHandler<ContaCorrenteMovimentacaoAdicionarCommand, ResponseCommand>
    {
        private readonly IContaCorrenteMovimentacaoSqlServerRepository _contaCorrenteMovimentacaoSqlServerRepository;

        public ContaCorrenteMovimentacaoAdicionarCommandHandler(IContaCorrenteMovimentacaoSqlServerRepository contaCorrenteMovimentacaoSqlServerRepository)
        {
            _contaCorrenteMovimentacaoSqlServerRepository = contaCorrenteMovimentacaoSqlServerRepository;
        }

        public Task<ResponseCommand> Handle(ContaCorrenteMovimentacaoAdicionarCommand request, CancellationToken cancellationToken)
        {
            // Validações de dados
            if (!request.Valido())
            {
                return Task.FromResult(new ResponseCommand(false, request.Erros));
            }

            // Persistir
            Models.ContaCorrenteMovimentacao contaCorrenteMovimentacaoRequest = new Models.ContaCorrenteMovimentacao
            {
                ContaCorrenteId = request.ContaCorrenteId,
                Valor = request.Valor,
                SaldoAtualizado = request.SaldoAtualizado,
                ContaCorrenteMovimentacaoTipoId = request.ContaCorrenteMovimentacaoTipoId,
                CriadaEm = request.CriadoEm
            };
            _contaCorrenteMovimentacaoSqlServerRepository.Adicionar(contaCorrenteMovimentacaoRequest);

            // Response
            return Task.FromResult(new ResponseCommand(true, contaCorrenteMovimentacaoRequest));
        }
    }
}