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
            ModuloDeInjecao.Servicos(ServiceCollection);
            ServiceProvider = ServiceCollection.BuildServiceProvider();
        }
        public void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}
