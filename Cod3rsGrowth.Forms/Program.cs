using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Infra;
using DotNetEnv;
using Cod3rsGrowth.Forms;
using Microsoft.Extensions.Hosting;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Test;

namespace test
{
    class Program
    {

        public static IServiceProvider serviceProvider { get; private set; }
        static void Main(string[] args)
        {
            var host = CreateHostBuilder().Build();
            serviceProvider = host.Services;

            ApplicationConfiguration.Initialize();

            // Update the database before running the application
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            Application.Run(new Form1(serviceProvider.GetRequiredService<ServicoClube>()));
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    Env.Load();
                    var connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");

                    // Add common FluentMigrator services
                    services.AddFluentMigratorCore()
                        .ConfigureRunner(rb => rb
                            // Add SQL Server support to FluentMigrator
                            .AddSqlServer()
                            // Set the connection string
                            .WithGlobalConnectionString(connectionString)
                            // Define the assembly containing the migrations
                            .ScanIn(typeof(TabelasMigrator).Assembly).For.Migrations())
                        // Enable logging to console in the FluentMigrator way
                        .AddLogging(lb => lb.AddFluentMigratorConsole());

                    ModuloInjetorInfra.Servicos(services);
                    ModuloInjetorServico.Servicos(services);
                });
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }
    }
}
