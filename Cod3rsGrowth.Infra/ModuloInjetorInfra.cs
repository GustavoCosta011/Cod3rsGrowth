using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Test.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using LinqToDB.AspNet;
using LinqToDB;
using Cod3rsGrowth.Infra;
using FluentMigrator.Runner;
using DotNetEnv;

namespace Cod3rsGrowth.Infra
{
    public class ModuloInjetorInfra
    {
        public static void Servicos(IServiceCollection ServicoInfra)
        {
            Env.Load();
            var connectionString = Environment.GetEnvironmentVariable("cntString");

            ServicoInfra.AddLinqToDBContext<Cod3rsGrowthConnect>((provider, options) => options.UseSqlServer(connectionString));

            ServicoInfra.AddScoped<IRepositoryData<Clube>, RepositoryClube>();
            ServicoInfra.AddScoped<IRepositoryData<Jogador>, RepositoryJogador>();

            ServicoInfra.AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(TabelasMigrator).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole());
        }

        public static void IniciarBanco(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }
        }
    }
}
