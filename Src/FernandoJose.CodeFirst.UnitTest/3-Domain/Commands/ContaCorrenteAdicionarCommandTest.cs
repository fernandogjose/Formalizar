using Bogus;
using FernandoJose.CodeFirst.Domain.ContaCorrente.Commands;
using System.Linq;
using Xunit;

namespace FernandoJose.CodeFirst.UnitTest._3_Domain.Commands
{
    public class ContaCorrenteAdicionarCommandTest
    {
        private readonly Faker _faker;

        public ContaCorrenteAdicionarCommandTest()
        {
            _faker = new Faker();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Quando_Agencia_Igual_Vazio_Ou_Nula_Deve_Exibir_Mensagem_De_Erro(string agencia)
        {
            ContaCorrenteAdicionarCommand adicionarCommand = new ContaCorrenteAdicionarCommand(agencia, "98765432", 1);

            adicionarCommand.Validar();

            Assert.True(!adicionarCommand.Valido());
            Assert.True(adicionarCommand.Erros?.FirstOrDefault(x => x == "Agencia é obrigatório") != null);
        }
    }
}
