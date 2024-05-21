using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Test.Testes
{
    public class UnitTest1 : Teste
    {
        private readonly IServicoClube<Clube> clubeServico;

        public UnitTest1() : base()
        {
            clubeServico = ServiceProvider.GetRequiredService<IServicoClube<Clube>>();
        }


        [Fact]
        public void Test1()
        {
            var Lista = clubeServico.ObterTodos();
            Assert.NotNull(Lista);
        }
        
    }
}