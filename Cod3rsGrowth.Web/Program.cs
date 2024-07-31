using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Servicos;
using Cod3rsGrowth.Web;

var builder = WebApplication.CreateBuilder(args);

ModuloInjetorServico.Servicos(builder.Services);
ModuloInjetorInfra.Servicos(builder.Services);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureProblemDetailsModelState();

var app = builder.Build();
app.UseProblemDetailsExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());
app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles(new StaticFileOptions
{
    ServeUnknownFileTypes = true
});
app.UseAuthorization();
app.MapControllers();
app.Run();
