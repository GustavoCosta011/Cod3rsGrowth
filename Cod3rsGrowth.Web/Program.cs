
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Servicos;
using Cod3rsGrowth.Web;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
var builder = WebApplication.CreateBuilder(args);

string? cntString = builder.Environment.EnvironmentName == "Tests" ? 
builder.Configuration.GetConnectionString("ConexaoTeste"):
builder.Configuration.GetConnectionString("ConexaoPadrao");

ModuloInjetorServico.Servicos(builder.Services);
ModuloInjetorInfra.Servicos(builder.Services, cntString);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureProblemDetailsModelState();
builder.Services.Configure<HttpsRedirectionOptions>(options =>
{
    options.HttpsPort = 7178;
});

var app = builder.Build();
if (args.Contains("--teste"))
{
    ModuloInjetorInfra.DeletarBancoDeDados(app.Services);
}
ModuloInjetorInfra.IniciarBanco(app.Services);

app.UseDefaultFiles();
app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "wwwroot")),
    ContentTypeProvider = new FileExtensionContentTypeProvider
    {
        Mappings = { [".properties"] = "application/x-msdownload" }
    }
});
app.UseProblemDetailsExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());
app.UseAuthorization();
app.MapControllers();
app.Run();
