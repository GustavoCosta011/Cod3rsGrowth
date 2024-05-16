using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Test
{
    public static class ModuloDeInjecao
    {
        public static void Servicos(IServiceCollection Servico)
        {
            Servico.AddScoped(typeof(IRepository<>), typeof(RepositoryMockClube));
            Servico.AddScoped(typeof(IRepository<>), typeof(RepositoryMockJogador));
            
        }
    }
}
