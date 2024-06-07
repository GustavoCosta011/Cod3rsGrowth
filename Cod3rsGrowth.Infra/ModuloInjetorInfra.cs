using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Test.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using LinqToDB.AspNet;
using LinqToDB;
using DotNetEnv;
 
namespace Cod3rsGrowth.Test
{
    public class ModuloInjetorInfra
    {


        public static void Servicos(IServiceCollection ServicosInfra)
        {
            Env.Load();
            Environment.GetEnvironmentVariable(connectionString);
            var strConnection = Environment.GetEnvironmentVariable("CONNECTIONSTRING");
            ServicosInfra.AddSingleton<IRepositoryData<Clube>, RepositoryClube>();
            ServicosInfra.AddSingleton<IRepositoryData<Jogador>, RepositoryJogador>();
            ServicosInfra.AddLinqToDBContext<Cod3rsGrowthConnect>((provider, options) => options.UseSqlServer(strConnection));
        }
    }
}
