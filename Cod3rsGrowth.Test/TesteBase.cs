using System;
using Microsoft.Extensions.DependencyInjection;


namespace Cod3rsGrowth.Test
{
    public class Teste : IDisposable
    {
        protected ServiceProvider ServiceProvider;


        public Teste(ServiceProvider serviceProvider)
        {
            var serviceCollection =  new ServiceCollection();
            ModuloDeInjecao.Servicos(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
