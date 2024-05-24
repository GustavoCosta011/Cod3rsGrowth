using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Enums;
using System.Security.Cryptography.X509Certificates;

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
            //Assert
            List<Clube> ListaObterTodos;

            //Arrange
            ListaObterTodos = clubeServico.ObterTodos();

            //Act
            Assert.NotNull(ListaObterTodos);
        }

        [Fact]
        public void DeveRetornarOTipoListaDeClubesAoObterTodos()
        {
            //Assert
            List<Clube> ListaObterTodos;

            //Arrange
            ListaObterTodos = clubeServico.ObterTodos();

            //Act
            Assert.Equal(typeof(List<Clube>), ListaObterTodos.GetType());
        }

        [Fact]
        public void DeveRetornarListaCompletaAoObterTodos()
        {
            //Assert
            List<Clube> Lista = new()
            {
                new(001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracanã",EstadosEnum.RJ, false,null)
            };

            //Arrange
            var ListaObterTodos = clubeServico.ObterTodos();

            //Act
            Assert.Equivalent(Lista,ListaObterTodos);
        }

        [Fact]
        public void DeveRetornarUmClubeNãoNuloAoObterPorId()
        {
            //Assert
            Clube clubeObterPorId;

            //Arrange
            clubeObterPorId = clubeServico.ObterPorId(1);

            //Act
            Assert.NotNull(clubeObterPorId);
        }

        [Fact]
        public void DeveRetornarTipoClubeAoObterPorId()
        {
            //Assert
            Clube clubeObterPorId;

            //Arrange
            clubeObterPorId = clubeServico.ObterPorId(1);

            //Act
            Assert.Equal(typeof(Clube), clubeObterPorId.GetType());
        }

        [Fact]
        public void DeveRetornarClubeCompletoAoObterPorId()
        {
            //Assert
            Clube clube  = new(001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracanã", EstadosEnum.RJ, false, null);

            //Arrange
            var clubeObterPorId = clubeServico.ObterPorId(1);

            //Act
            Assert.Equivalent(clube,clubeObterPorId);
        }

        [Fact]
        public void DeveRetornarErrorMessageAoCriarComExcecao()
        {
            //Assert
            List<int> elenco = new(){12,13,14};
            var clube = new Clube(null, "FC", DateTime.Parse("22-12-1950"), "Pimba Arena", EstadosEnum.TO, true, elenco );

            //Arrange
            var result = Assert.Throws<Exception>(() => clubeServico.CriarClube(clube));

            //Act
            Assert.Equal("O nome tem que ter no minimo 3 e no maximo 60 letras!!", result.Message);
        }

        [Fact]
        public void DeveRetornarClubeAoCriarComExcecao()
        {
            //Assert
            List<int> elenco = new() { 18, 20, 13 };
            var clubeesperado = new Clube(003, "FC Pimba", DateTime.Parse("22-12-1938"), "Pimba Arena", EstadosEnum.TO, true, elenco);
            var clube = new Clube(null, "FC Pimba", DateTime.Parse("22-12-1938"), "Pimba Arena", EstadosEnum.TO, true, elenco);

            //Arrange
            clubeServico.CriarClube(clube);
            var resultClube =  clubeServico.ObterPorId(003);

            //Act
            Assert.Equivalent(clubeesperado,resultClube);
        }


    }
}