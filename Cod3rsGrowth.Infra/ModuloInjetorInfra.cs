using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Test.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using LinqToDB.AspNet;
using LinqToDB;
using FluentMigrator.Runner;
using DotNetEnv;

namespace Cod3rsGrowth.Infra
{
    public class ModuloInjetorInfra
    {
        public static void Servicos(IServiceCollection ServicoInfra, string connectionString)
        {
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
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                Console.WriteLine("Starting migrations...");
                runner.MigrateUp();
                Console.WriteLine("Migrations completed.");
            }
        }

        public static void DeletarBancoDeDados(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var executor = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                try
                {
                    executor.MigrateDown(0);
                    Console.WriteLine("As tabelas foram apagadas");
                }
                catch (Exception erro)
                {
                    Console.WriteLine($"Erro em apagar tabelas :\n{erro.Message}");
                    throw;
                }
            }
        }
    }
}
