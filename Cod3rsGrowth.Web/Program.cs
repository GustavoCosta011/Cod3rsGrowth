using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Servicos;
using Cod3rsGrowth.Web;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

ModuloInjetorServico.Servicos(builder.Services);
ModuloInjetorInfra.Servicos(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureProblemDetailsModelState();

var app = builder.Build();
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
