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
        static void Main(string[] args)
        {
            var host = CreateHostBuilder().Build();

            ApplicationConfiguration.Initialize();

            // Update the database before running the application
            using (var scope = host.Services.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }

            Application.Run(host.Services.GetRequiredService<Form1>());
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    Env.Load();
                    var connectionString = Environment.GetEnvironmentVariable("CONNECTIONSTRING");

                    services.AddTransient<Form1>();

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

        /// <summary>
        /// Update the database
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
        }
    }
}
