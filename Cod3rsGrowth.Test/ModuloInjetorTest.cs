using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Test.RepositoriosTest;
using Microsoft.Extensions.DependencyInjection;


namespace Cod3rsGrowth.Test
{
    public static class ModuloInjetorTest
    {
        public static void Servicos(IServiceCollection ServicosTest)
        {
            ServicosTest.AddSingleton<ServicoClube>();
            ServicosTest.AddSingleton<ServicoJogador>();
        }
    }
}
