using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Test.Testes
{
    public class Test_servico_clube : Teste
    {
        private readonly IServicoClube<Clube> clubeServico;

        public Test_servico_clube() : base()
        {
            clubeServico = ServiceProvider.GetRequiredService<IServicoClube<Clube>>();
        }


        [Fact]
        public void ListaDeClubesObterTodosNaoNula()
        {
            var Lista = clubeServico.ObterTodos();
            Assert.NotNull(Lista);
        }

        [Fact]
        public void ResultadoDoObterTodosDoTipoLista()
        {
            var Lista2 = clubeServico.ObterTodos();
           
            Assert.Equal(typeof(List<Clube>), Lista2.GetType());
        }
        
    }
}