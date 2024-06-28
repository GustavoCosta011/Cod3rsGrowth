using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Servicos;

var builder = WebApplication.CreateBuilder(args);

ModuloInjetorServico.Servicos(builder.Services);
ModuloInjetorInfra.Servicos(builder.Services);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
