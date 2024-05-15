using System;
using Microsoft.Extensions.DependencyInjection;


namespace Cod3rsGrowth.Test
{


    public class Teste : IDisposable
    {
        protected ServiceProvider _serviceProvider;


        public Teste(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
