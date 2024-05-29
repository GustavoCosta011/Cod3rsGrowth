using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Test.RepositoriosTest;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Test
{
    public static class ModuloDeInjecao
    {
        public static void Servicos(IServiceCollection Servico)
        {

            Servico.AddSingleton<IRepositoryData<Clube>, RepositoryTestClube>();
            Servico.AddSingleton<IRepositoryData<Jogador>, RepositoryTestJogador>();
            Servico.AddSingleton<ServicoClube>();
            Servico.AddSingleton<ServicoJogador>();
            Servico.AddSingleton<ValidadorJogador>();
            Servico.AddSingleton<ValidadorClube>();
        }
    }
}
