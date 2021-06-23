using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FernandoJose.CodeFirst.Domain.ContaCorrente.Interfaces.SqlServerRepositories
{
    public interface IContaCorrenteSqlServerRepository
    {
        void Adicionar(Models.ContaCorrente contaCorrenteRequest);

        void Atualizar(Models.ContaCorrente contaCorrenteRequest);

        void Deletar(Models.ContaCorrente contaCorrenteRequest);

        Models.ContaCorrente Obter(Expression<Func<Models.ContaCorrente, bool>> predicate);

        List<Models.ContaCorrente> Listar(Expression<Func<Models.ContaCorrente, bool>> predicate);
    }
}
