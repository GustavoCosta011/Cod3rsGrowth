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

            Servico.AddScoped<IRepositoryData<Clube>, RepositoryMockClube>();
            Servico.AddScoped<IRepositoryData<Jogador>, RepositoryMockJogador>();
            Servico.AddScoped<IServicoClube<Clube>, ServicoClube>();
            //Servico.AddSingleton<IServicoClube<Jogador>, ServicoJogador>();
        }
    }
}
