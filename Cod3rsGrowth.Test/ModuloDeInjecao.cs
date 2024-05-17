using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Test.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Test
{
    public static class ModuloDeInjecao
    {
        public static void Servicos(IServiceCollection Servico)
        {
            Servico.AddScoped<IRepository<Clube>, RepositoryMockClube>();
            Servico.AddScoped<IRepository<Jogador>, RepositoryMockJogador>();

        }
    }
}
