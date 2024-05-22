using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Test.Testes
{
    public class Test_servico_jogador : Teste
    {
        private readonly IServicoJogador jogadorServico;

        public Test_servico_jogador() : base()
        {
            jogadorServico = ServiceProvider.GetRequiredService<IServicoJogador>();
        }



        [Fact]
        public void DeveRetornarListaNaoNulaDeClubesAoObterTodos()
        {
            var Lista = jogadorServico.ObterTodos();
            Assert.NotNull(Lista);
        }

        [Fact]
        public void DeveRetornarOTipoListaDeJogadorAoObterTodos()
        {
            var ListaObterTodos = jogadorServico.ObterTodos();

            Assert.Equal(typeof(List<Jogador>), ListaObterTodos.GetType());
        }

        [Fact]
        public void DeveRetornarListaCompletaAoObterTodos()
        {
            List<Jogador> Lista = new()
            {
                new(10, "Gabi", 27, DateTime.Parse("30-08-1996"), 1.78, 68.0),
                new(11, "PedroQuexada", 25, DateTime.Parse("17-01-1998"), 1.88, 78.0),
                new(12, "Sabino", 19, DateTime.Parse("03-03-2005"), 1.70, 73.0),
                new(13, "Halandinho", 17, DateTime.Parse("30-08-2007"), 1.75, 76.0),
                new(14, "Penaldo", 33, DateTime.Parse("30-09-1991"), 1.77, 89.0),
                new(15, "Pepssi", 30, DateTime.Parse("17-10-1994"), 1.90, 77.0),
                new(16, "HulkBundaGol", 35, DateTime.Parse("22-12-1989"), 1.68, 69.0)
            };
            var ListaObterTodos = jogadorServico.ObterTodos();
            Assert.Equivalent(Lista, ListaObterTodos);
        }
    }
}