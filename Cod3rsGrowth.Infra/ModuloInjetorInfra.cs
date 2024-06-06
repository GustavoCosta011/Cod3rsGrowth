using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Test.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Test
{
    public static class ModuloDeInjecaoInfra
    {
        public static void Servicos(IServiceCollection ServicosInfra)
        {
            ServicosInfra.AddSingleton<IRepositoryData<Clube>, RepositoryClube>();
            ServicosInfra.AddSingleton<IRepositoryData<Jogador>, RepositoryJogador>();
        }
    }
}
