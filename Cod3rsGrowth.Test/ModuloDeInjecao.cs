using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.RepositoriosTest;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Validadores;

namespace Cod3rsGrowth.Test
{
    public static class ModuloDeInjecao
    {
        public static void Servicos(IServiceCollection Servico)
        {

            Servico.AddSingleton<IRepositoryData<Clube>, RepositoryClube>();
            Servico.AddSingleton<IRepositoryData<Jogador>, RepositoryJogador>();
            Servico.AddSingleton<IServicoClube, ServicoClube>();
            Servico.AddSingleton<IServicoJogador, ServicoJogador>();
            Servico.AddSingleton<ValidadorJogador>();
        }
    }
}
