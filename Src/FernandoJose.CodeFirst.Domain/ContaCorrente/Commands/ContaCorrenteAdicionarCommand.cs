using FernandoJose.CodeFirst.Domain.Share.Commands;
using MediatR;
using System;
using System.Collections.Generic;

namespace FernandoJose.CodeFirst.Domain.ContaCorrente.Commands
{
    public class ContaCorrenteAdicionarCommand : RequestCommand, IRequest<ResponseCommand>
    {
        public string Agencia { get; }

        public string Conta { get; }

        public int ContaCorrenteTipoId { get; set; }

        public DateTime CriadoEm { get; set; }

        public ContaCorrenteAdicionarCommand(string agencia, string conta, int contaCorrenteTipoId)
        {
            Agencia = agencia;
            Conta = conta;
            ContaCorrenteTipoId = contaCorrenteTipoId;
            CriadoEm = DateTime.Now;
        }

        public override void Validar()
        {
            Erros = new List<string>(0);

            if (string.IsNullOrEmpty(Agencia))
            {
                Erros.Add("Agencia é obrigatório");
            }

            if (string.IsNullOrEmpty(Conta))
            {
                Erros.Add("Conta é obrigatório");
            }

            if (ContaCorrenteTipoId <= 0)
            {
                Erros.Add("ContaCorrenteTipoId é obrigatório");
            }
        }
    }
}
