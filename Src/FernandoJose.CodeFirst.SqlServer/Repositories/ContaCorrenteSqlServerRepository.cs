using FernandoJose.CodeFirst.Domain.ContaCorrente.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.ContaCorrente.Models;
using FernandoJose.CodeFirst.SqlServer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FernandoJose.CodeFirst.SqlServer.Repositories
{
    public class ContaCorrenteSqlServerRepository : IContaCorrenteSqlServerRepository
    {
        public void Adicionar(ContaCorrente contaCorrenteRequest)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            db.ContaCorrentes.Add(contaCorrenteRequest);
            db.SaveChanges();
        }

        public void Atualizar(ContaCorrente contaCorrenteRequest)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            db.ContaCorrentes.Update(contaCorrenteRequest);
            db.SaveChanges();
        }

        public void Deletar(ContaCorrente contaCorrenteRequest)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            db.ContaCorrentes.Remove(contaCorrenteRequest);
            db.SaveChanges();
        }

        public ContaCorrente Obter(Expression<Func<ContaCorrente, bool>> predicate)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            return db.ContaCorrentes.FirstOrDefault(predicate);
        }

        public List<ContaCorrente> Listar(Expression<Func<ContaCorrente, bool>> predicate)
        {
            using var db = new FernandoJoseCodeFirstDbContext();
            return db.ContaCorrentes.Where(predicate).OrderBy(x => x.Agencia).OrderBy(x => x.Conta).ToList();
        }
    }
}
