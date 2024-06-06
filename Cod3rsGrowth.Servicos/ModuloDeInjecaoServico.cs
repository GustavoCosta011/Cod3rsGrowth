
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Test
{
    public static class ModuloDeInjecaoServico
    {
        public static void Servicos(IServiceCollection ServicosServico)
        {
            ServicosServico.AddSingleton<ServicoClube>();
            ServicosServico.AddSingleton<ServicoJogador>();
            ServicosServico.AddSingleton<ValidadorJogador>();
            ServicosServico.AddSingleton<ValidadorClube>();
        }
    }
}
