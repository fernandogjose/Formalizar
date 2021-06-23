using FernandoJose.CodeFirst.Domain.Share.Commands;
using MediatR;
using System;
using System.Collections.Generic;

namespace FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Commands
{
    public class ContaCorrenteMovimentacaoAdicionarCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public int ContaCorrenteId { get; set; }

        public int ContaCorrenteMovimentacaoTipoId { get; set; }

        public decimal Valor { get; }

        public decimal SaldoAtualizado { get; }

        public DateTime CriadoEm { get; set; }

        public ContaCorrenteMovimentacaoAdicionarCommand(int contaCorrenteId, decimal valor, decimal saldoAtualizado, int contaCorrenteMovimentacaoTipoId)
        {
            ContaCorrenteId = contaCorrenteId;
            Valor = valor;
            SaldoAtualizado = saldoAtualizado;
            ContaCorrenteMovimentacaoTipoId = contaCorrenteMovimentacaoTipoId;
            CriadoEm = DateTime.Now;
        }

        public override void Validar()
        {
            Erros = new List<string>(0);

            if (ContaCorrenteId <= 0)
            {
                Erros.Add("ContaCorrenteId é obrigatório");
            }

            if (Valor <= 0)
            {
                Erros.Add("Valor é obrigatório");
            }

            if (SaldoAtualizado <= 0)
            {
                Erros.Add("SaldoAtualizado é obrigatório");
            }

            if (ContaCorrenteMovimentacaoTipoId <= 0)
            {
                Erros.Add("ContaCorrenteMovimentacaoTipoId é obrigatório");
            }
        }
    }
}
