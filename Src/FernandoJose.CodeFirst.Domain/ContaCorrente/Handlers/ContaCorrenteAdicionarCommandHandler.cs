using FernandoJose.CodeFirst.Domain.ContaCorrente.Commands;
using FernandoJose.CodeFirst.Domain.ContaCorrente.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.Share.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FernandoJose.CodeFirst.Domain.ContaCorrente.Handlers
{
    public class ContaCorrenteAdicionarCommandHandler : IRequestHandler<ContaCorrenteAdicionarCommand, ResponseCommand>
    {
        private readonly IContaCorrenteSqlServerRepository _contaCorrenteSqlServerRepository;

        public ContaCorrenteAdicionarCommandHandler(IContaCorrenteSqlServerRepository contaCorrenteSqlServerRepository)
        {
            _contaCorrenteSqlServerRepository = contaCorrenteSqlServerRepository;
        }

        public Task<ResponseCommand> Handle(ContaCorrenteAdicionarCommand request, CancellationToken cancellationToken)
        {
            // Validações de dados
            if (!request.Valido())
            {
                return Task.FromResult(new ResponseCommand(false, request.Erros));
            }

            // Persistir
            Models.ContaCorrente contaCorrenteRequest = new Models.ContaCorrente
            {
                Agencia = request.Agencia,
                Conta = request.Conta,
                ContaCorrenteTipoId = request.ContaCorrenteTipoId,
                CriadaEm = request.CriadoEm
            };
            _contaCorrenteSqlServerRepository.Adicionar(contaCorrenteRequest);

            // Response
            return Task.FromResult(new ResponseCommand(true, contaCorrenteRequest));
        }
    }
}