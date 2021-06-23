using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Interfaces.SqlServerRepositories
{
    public interface IContaCorrenteMovimentacaoSqlServerRepository
    {
        void Adicionar(Models.ContaCorrenteMovimentacao contaCorrenteMovimentacaoRequest);

        Models.ContaCorrenteMovimentacao Obter(Expression<Func<Models.ContaCorrenteMovimentacao, bool>> predicate);

        List<Models.ContaCorrenteMovimentacao> Listar(Expression<Func<Models.ContaCorrenteMovimentacao, bool>> predicate);
    }
}
