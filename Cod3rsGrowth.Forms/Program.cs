using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Forms;
using Microsoft.Extensions.Hosting;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Test;
using Cod3rsGrowth.Servicos;

namespace Forms
{
    class Program
    {
        private static ServiceProvider? _serviceProvider;

        static void Main()
        {
            var ServiceCollection = new ServiceCollection();
            ModuloInjetorInfra.Servicos(ServiceCollection);
            ModuloInjetorServico.Servicos(ServiceCollection);
            _serviceProvider = ServiceCollection.BuildServiceProvider();

            ModuloInjetorInfra.IniciarBanco(_serviceProvider);

            ApplicationConfiguration.Initialize();
            Application.Run(new FormPrincipal(_serviceProvider.GetRequiredService<ServicoClube>(), _serviceProvider.GetRequiredService<ServicoJogador>()));
        }
    }
}
