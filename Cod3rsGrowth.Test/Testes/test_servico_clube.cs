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
            //Arrange
            List<Clube> ListaObterTodos;

            //Act
            ListaObterTodos = clubeServico.ObterTodos();

            //Assert
            Assert.NotNull(ListaObterTodos);
        }

        [Fact]
        public void DeveRetornarOTipoListaDeClubesAoObterTodos()
        {
            //Arrange
            List<Clube> ListaObterTodos;

            //Act
            ListaObterTodos = clubeServico.ObterTodos();

            //Assert
            Assert.Equal(typeof(List<Clube>), ListaObterTodos.GetType());
        }

        [Fact]
        public void DeveRetornarListaCompletaAoObterTodos()
        {
            ////Arrange
            List<Clube> Lista = new()
            {
                new(001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracanã",EstadosEnum.RJ, false,null)
            };

            //Act
            var ListaObterTodos = clubeServico.ObterTodos();

            //Assert
            Assert.Equivalent(Lista,ListaObterTodos);
        }

        [Fact]
        public void DeveRetornarUmClubeNãoNuloAoObterPorId()
        {
            //Arrange
            Clube clubeObterPorId;
            int IdEsperado = 001;

            //Act
            clubeObterPorId = clubeServico.ObterPorId(IdEsperado);

            //Assert
            Assert.NotNull(clubeObterPorId);
        }

        [Fact]
        public void DeveRetornarTipoClubeAoObterPorId()
        {
            //Arrange
            Clube clubeObterPorId;
            int IdEsperado = 001;

            //Act
            clubeObterPorId = clubeServico.ObterPorId(IdEsperado);

            //Assert
            Assert.Equal(typeof(Clube), clubeObterPorId.GetType());
        }

        [Fact]
        public void DeveRetornarClubeCompletoAoObterPorId()
        {
            //Arrange
            Clube clube  = new(001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracanã", EstadosEnum.RJ, false, null);
            int IdEsperado = 001;

            //Act
            var clubeObterPorId = clubeServico.ObterPorId(IdEsperado);

            //Assert
            Assert.Equivalent(clube,clubeObterPorId);
        }

        [Fact]
        public void DeveRetornarErrorMessageAoCriarComExcecao()
        {
            //Arrange
            List<int> elenco = new(){12,13,14};
            var clube = new Clube(null, "FC", DateTime.Parse("22-12-1950"), "Pimba Arena", EstadosEnum.TO, true, elenco );

            //Act
            var result = Assert.Throws<Exception>(() => clubeServico.CriarClube(clube));

            //Assert
            Assert.Equal("O nome tem que ter no minimo 3 e no maximo 60 letras!!", result.Message);
        }

        [Fact]
        public void DeveRetornarClubeAoCriarComExcecao()
        {
            //Arrange
            List<int> elenco = new() { 18, 20, 13 };
            var clubeesperado = new Clube(003, "FC Pimba", DateTime.Parse("22-12-1938"), "Pimba Arena", EstadosEnum.TO, true, elenco);
            var clube = new Clube(null, "FC Pimba", DateTime.Parse("22-12-1938"), "Pimba Arena", EstadosEnum.TO, true, elenco);
            int IdEsperado = 003;
            //Act
            clubeServico.CriarClube(clube);
            var resultClube =  clubeServico.ObterPorId(IdEsperado);

            //Assert
            Assert.Equivalent(clubeesperado,resultClube);
        }


    }
}