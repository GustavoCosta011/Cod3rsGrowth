using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Test.RepositoriosTest;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Test
{
    public static class ModuloDeInjecao
    {
        public static void Servicos(IServiceCollection Servico)
        {
            Servico.AddSingleton<IRepositoryClube<Clube>, RepositoryMockClube>();
            

        }
    }
}
