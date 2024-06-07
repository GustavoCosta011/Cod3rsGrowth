using System;
using Microsoft.Extensions.DependencyInjection;


namespace Cod3rsGrowth.Test
{
    public class Teste : IDisposable
    {
        protected ServiceProvider ServiceProvider;


        public Teste()
        {
            var ServiceCollection = new ServiceCollection();
            ModuloInjetorInfra.Servicos(ServiceCollection);
            ModuloInjetorServico.Servicos(ServiceCollection);
            ModuloInjetorTest.Servicos(ServiceCollection);
            ServiceProvider = ServiceCollection.BuildServiceProvider();
        }
        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}
