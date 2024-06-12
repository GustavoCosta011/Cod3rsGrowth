using System;
using Microsoft.Extensions.DependencyInjection;


namespace Cod3rsGrowth.Test
{
    public class Teste : IDisposable
    {
        protected ServiceProvider _serviceProvider;


        public Teste()
        {
            var ServiceCollection = new ServiceCollection();
            ModuloInjetorInfra.Servicos(ServiceCollection);
            ModuloInjetorServico.Servicos(ServiceCollection);
            ModuloInjetorTest.Servicos(ServiceCollection);
            _serviceProvider = ServiceCollection.BuildServiceProvider();
        }
        public void Dispose()
        {
            _serviceProvider.Dispose();
        }
    }
}
