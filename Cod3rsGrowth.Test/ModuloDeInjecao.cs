using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.RepositoriosTest;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Test
{
    public static class ModuloDeInjecao
    {
        public static void Servicos(IServiceCollection Servico)
        {

            Servico.AddSingleton<IRepositoryData<Clube>, RepositoryMockClube>();
            Servico.AddSingleton<IRepositoryData<Jogador>, RepositoryMockJogador>();
            Servico.AddSingleton<IServicoClube, ServicoClube>();
            Servico.AddSingleton<IServicoJogador, ServicoJogador>();
        }
    }
}
