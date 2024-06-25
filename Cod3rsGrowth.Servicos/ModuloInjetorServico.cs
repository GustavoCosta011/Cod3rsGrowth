using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Servicos
{
    public static class ModuloInjetorServico
    {
        public static void Servicos(IServiceCollection ServicosServico)
        {
            ServicosServico.AddScoped<ServicoClube>();
            ServicosServico.AddScoped<ServicoJogador>();
            ServicosServico.AddScoped<ValidadorJogador>();
            ServicosServico.AddScoped<ValidadorClube>();
        }
    }
}
