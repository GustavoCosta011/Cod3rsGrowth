using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Test.Testes
{
    public class Test_servico_clube : Teste
    {
        private readonly IServicoClube clubeServico;

        public Test_servico_clube() : base()
        {
            clubeServico = ServiceProvider.GetRequiredService<IServicoClube>();
        }


        [Fact]
        public void DeveRetornarListaNaoNulaDeClubesAoObterTodos()
        {
            var Lista = clubeServico.ObterTodos();
            Assert.NotNull(Lista);
        }

        [Fact]
        public void DeveRetornarOTipoListaDeClubesAoObterTodos()
        {
            var ListaObterTodos = clubeServico.ObterTodos();

            Assert.Equal(typeof(List<Clube>), ListaObterTodos.GetType());
        }

        [Fact]
        public void DeveRetornarListaCompletaAoObterTodos()
        {
            List<Clube> Lista = new()
            {
                new(001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracană",EstadosEnum.RJ, false,null)
            };
            var ListaObterTodos = clubeServico.ObterTodos();
            Assert.Equivalent(Lista,ListaObterTodos);
        }

    }
}