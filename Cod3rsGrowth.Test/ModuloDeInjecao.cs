using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Test
{
    public static class ModuloDeInjecao
    {
        public static void Servicos(IServiceCollection Servico)
        {
            Servico.AddSingleton(typeof(IRepository<>), typeof(RepositoryMockClube));
            Servico.AddSingleton(typeof(IRepository<>), typeof(RepositoryMockJogador));
            
        }
    }
}
