using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Test.RepositoriosTest;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Test
{
    public static class ModuloInjetorTest
    {
        public static void Servicos(IServiceCollection ServicosTest)
        {
            ServicosTest.AddSingleton<IRepositoryData<Clube>, RepositoryTestClube>();
            ServicosTest.AddSingleton<IRepositoryData<Jogador>, RepositoryTestJogador>();
        }
    }
}
