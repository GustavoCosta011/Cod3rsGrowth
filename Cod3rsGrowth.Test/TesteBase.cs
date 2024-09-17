using System;
using Cod3rsGrowth.Servicos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Test.Testes;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Test.Repositorios;
using FluentMigrator.Runner;


namespace Cod3rsGrowth.Test
{
    public class Teste : IDisposable
    {
        protected ServiceProvider _serviceProvider;

        public Teste()
        {
            var serviceCollection = new ServiceCollection();
            ModuloInjetorServico.Servicos(serviceCollection);
            ModuloInjetorTest.Servicos(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}
