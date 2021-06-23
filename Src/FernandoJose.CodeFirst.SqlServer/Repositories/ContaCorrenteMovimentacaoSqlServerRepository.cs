using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Models;
using FernandoJose.CodeFirst.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FernandoJose.CodeFirst.SqlServer.Repositories
{
    public class ContaCorrenteMovimentacaoSqlServerRepository : IContaCorrenteMovimentacaoSqlServerRepository
    {
        public void Adicionar(ContaCorrenteMovimentacao contaCorrenteMovimentacaoRequest)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            db.ContaCorrenteMovimentacaos.Add(contaCorrenteMovimentacaoRequest);
            db.SaveChanges();
        }

        public ContaCorrenteMovimentacao Obter(Expression<Func<ContaCorrenteMovimentacao, bool>> predicate)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            return db.ContaCorrenteMovimentacaos.LastOrDefault(predicate);
        }

        public List<ContaCorrenteMovimentacao> Listar(Expression<Func<ContaCorrenteMovimentacao, bool>> predicate)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            return db.ContaCorrenteMovimentacaos.Where(predicate).ToList();
        }
    }
}
