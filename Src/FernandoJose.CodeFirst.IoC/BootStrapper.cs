using FernandoJose.CodeFirst.Application.ContaCorrente.AppServices;
using FernandoJose.CodeFirst.Application.ContaCorrente.Interfaces;
using FernandoJose.CodeFirst.Application.ContaCorrenteMovimentacao.AppServices;
using FernandoJose.CodeFirst.Application.ContaCorrenteMovimentacao.Interfaces;
using FernandoJose.CodeFirst.Domain.ContaCorrente.Commands;
using FernandoJose.CodeFirst.Domain.ContaCorrente.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Commands;
using FernandoJose.CodeFirst.Domain.ContaCorrenteMovimentacao.Interfaces.SqlServerRepositories;
using FernandoJose.CodeFirst.Domain.Share.Pipelines;
using FernandoJose.CodeFirst.SqlServer.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FernandoJose.CodeFirst.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Sql Server Repository
            services.AddTransient<IContaCorrenteSqlServerRepository, ContaCorrenteSqlServerRepository>();
            services.AddTransient<IContaCorrenteMovimentacaoSqlServerRepository, ContaCorrenteMovimentacaoSqlServerRepository>();

            // Application
            services.AddTransient<IContaCorrenteAppService, ContaCorrenteAppService>();
            services.AddTransient<IContaCorrenteMovimentacaoAppService, ContaCorrenteMovimentacaoAppService>();

            // Command e Handler
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidacaoPipeline<,>));
            services.AddMediatR(typeof(ContaCorrenteAdicionarCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(ContaCorrenteMovimentacaoAdicionarCommand).GetTypeInfo().Assembly);
        }
    }
}