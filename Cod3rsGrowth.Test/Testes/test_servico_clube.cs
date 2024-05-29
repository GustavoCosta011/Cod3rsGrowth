using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Test.Singletons.Singleton;

namespace Cod3rsGrowth.Test.Testes
{
    public class Test_servico_clube : Teste
    {
        private readonly ServicoClube clubeServico;
       
        public Test_servico_clube() : base()
        {
            clubeServico = ServiceProvider.GetRequiredService<ServicoClube>();
        }

//OBTER TODOS

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

//OBTER POR ID

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

//CRIAR

        [Fact]
        public void DeveRetornarErrorMessageAoCriarComExcecao()
        {
            //Arrange
            List<int> elenco = new(){12,13,14};
            var clube = new Clube(0, "FC", DateTime.Parse("22-12-1950"), "Pimba Arena", EstadosEnum.TO, true, elenco );

            //Act
            var result = Assert.Throws<Exception>(() => clubeServico.CriarClube(clube));

            //Assert
            Assert.Equal("O nome tem que ter no minimo 3 e no maximo 60 letras!!", result.Message);
        }

        [Fact]
        public void DeveRetornarClubeAoCriar()
        {
            //Arrange
            List<int> elenco = new() { 18, 20, 13 };
            var clubeesperado = new Clube(002, "FC Pimba", DateTime.Parse("22-12-1938"), "Pimba Arena", EstadosEnum.TO, true, elenco);
            var clube = new Clube(0, "FC Pimba", DateTime.Parse("22-12-1938"), "Pimba Arena", EstadosEnum.TO, true, elenco);
            int IdEsperado = 002;
            //Act
            clubeServico.CriarClube(clube);
            var resultClube = ClasseSingleton.Instance.Clubes.Find(clube => clube.Id == IdEsperado) ?? throw new Exception("Clube inexistente!");

            //Assert
            Assert.Equivalent(clubeesperado,resultClube);
        }

//EDITAR

        [Fact]
        public void DeveRetornarClubeCompletoAoEditar()
        {
            //Arrange
            var clubeEsperado = new Clube(001, "Mengao", DateTime.Parse("17-01-2004"), "Maracanã", EstadosEnum.GO, true, null);
            var mudancas = new Clube(0, "Mengao", DateTime.Parse("17-01-2004"), "Maracanã", EstadosEnum.GO,true,null);
            var IdDoClubeASerEditado = 1;

            //Act
            clubeServico.EditarClube(IdDoClubeASerEditado, mudancas);
            var result = ClasseSingleton.Instance.Clubes.Find(clube => clube.Id == IdDoClubeASerEditado) ?? throw new Exception("Clube inexistente!");

            //Assert
            Assert.Equivalent(clubeEsperado, result);
        }

        [Fact]
        public void DeveRetornarExceptionAoEditar()
        {
            //Arrange
            var clubeEsperado = new Clube(001, "Mengao", DateTime.Parse("17-01-2004"), "Maracanã", EstadosEnum.GO, true, null);
            var mudancas = new Clube(001, "Fl", DateTime.Parse("17-01-2025"), "Maracanã", EstadosEnum.GO, true, null);
            var IdDoClubeASerEditado = 1;
            var mensagemErro = "O nome tem que ter no minimo 3 e no maximo 60 letras!!" +
                "A data deve ser anterior a atual!!";

            //Act
            var result = Assert.Throws<Exception>(() => clubeServico.EditarClube(IdDoClubeASerEditado, mudancas));

            //Assert
            Assert.Equal(mensagemErro, result.Message);

        }

//REMOVER

        [Fact]
        public void DeveRetornarQueOClubeFoiRemovido()

        {
            //Arrange
            var idDoClubeAserRemovido = 2;
            var mensagemDeBusca = "Clube inexistente!";

            //Act
            clubeServico.RemoverClube(idDoClubeAserRemovido);
            var result = Assert.Throws<Exception>(() => ClasseSingleton.Instance.Clubes.Find(clube => clube.Id == idDoClubeAserRemovido) ?? throw new Exception("Clube inexistente!"));

            //Assert
            Assert.Equal(mensagemDeBusca, result.Message);

        }
        [Fact]
        public void DeveRetornarExceptionaoRemoverClube()

        {
            //Arrange
            var idDoClubeAserRemovido = 5;
            var mensagemDeBusca = "Clube inexistente!";

            //Act
            var result = Assert.Throws<Exception>(() => clubeServico.RemoverClube(idDoClubeAserRemovido));

            //Assert
            Assert.Equal(mensagemDeBusca, result.Message);

        }
    }
}