using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Servicos;
using Cod3rsGrowth.Web;

var builder = WebApplication.CreateBuilder(args);

ModuloInjetorServico.Servicos(builder.Services);
ModuloInjetorInfra.Servicos(builder.Services);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureProblemDetailsModelState();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseProblemDetailsExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
