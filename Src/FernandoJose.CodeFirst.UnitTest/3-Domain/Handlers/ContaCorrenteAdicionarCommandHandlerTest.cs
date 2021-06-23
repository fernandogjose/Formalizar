using Bogus;
using FernandoJose.CodeFirst.Domain.ContaCorrente.Commands;
using FernandoJose.CodeFirst.Domain.ContaCorrente.Handlers;
using FernandoJose.CodeFirst.Domain.ContaCorrente.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.ContaCorrente.Models;
using FernandoJose.CodeFirst.Domain.Share.Commands;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FernandoJose.CodeFirst.UnitTest._3_Domain.Handlers
{
    public class ContaCorrenteAdicionarCommandHandlerTest
    {
        private readonly Faker _faker;
        private readonly ContaCorrenteAdicionarCommandHandler _adicionarCommandHandler;
        private readonly Mock<IContaCorrenteSqlServerRepository> _sqlServerRepositoryMock;

        public ContaCorrenteAdicionarCommandHandlerTest()
        {
            // Faker
            _faker = new Faker();

            // Mock
            _sqlServerRepositoryMock = new Mock<IContaCorrenteSqlServerRepository>();

            // CommandHandler
            _adicionarCommandHandler = new ContaCorrenteAdicionarCommandHandler(_sqlServerRepositoryMock.Object);
        }

        [Fact]
        public async Task Quando_Parametros_Corretos_Deve_Cadastrar_Com_Sucesso()
        {
            // Arrange
            ContaCorrenteAdicionarCommand adicionarCommand = new ContaCorrenteAdicionarCommand("1234", "98765432", 1);
            _sqlServerRepositoryMock.Setup(r => r.Adicionar(It.IsAny<ContaCorrente>()));

            // Action
            ResponseCommand response = await _adicionarCommandHandler.Handle(adicionarCommand, CancellationToken.None).ConfigureAwait(true);

            // Assert
            Assert.True(response.Sucesso);
            Assert.True(response.Objeto != null);
        }
    }
}
