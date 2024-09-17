using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Test.Singletons.Singleton;
using FluentValidation;

namespace Cod3rsGrowth.Test.Testes
{
    public class Test_servico_clube : Teste
    {
        private readonly ServicoClube clubeServico;
        private readonly List<Clube> database;

        public Test_servico_clube() : base()
        {
            clubeServico = _serviceProvider.GetRequiredService<ServicoClube>();
            database = ClasseSingleton.Instance.Clubes;
        }

        //OBTER TODOS

        [Fact]
        public void DeveRetornarListaNaoNulaDeClubesAoObterTodos()
        {
            //Arrange
            List<ClubeDto> ListaObterTodos;

            //Act
            ListaObterTodos = clubeServico.ObterTodos(null);

            //Assert
            Assert.NotNull(ListaObterTodos);
        }

        [Fact]
        public void DeveRetornarOTipoListaDeClubesAoObterTodos()
        {
            //Arrange
            List<ClubeDto> ListaObterTodos;

            //Act
            ListaObterTodos = clubeServico.ObterTodos(null);

            //Assert
            Assert.Equal(typeof(List<ClubeDto>), ListaObterTodos.GetType());
        }

        [Fact]
        public void DeveRetornarListaCompletaAoObterTodos()
        {
            //Arrange
            List<ClubeDto> Lista = new()
            {
                new(001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracanã", "Rio de Janeiro",EstadosEnum.RJ, false,null)
            };

            //Act
            var ListaObterTodos = clubeServico.ObterTodos(null);

            //Assert
            Assert.Equivalent(Lista, ListaObterTodos);
        }

        //OBTER POR ID

        [Fact]
        public void DeveRetornarUmClubeNãoNuloAoObterPorId()
        {
            //Arrange
            ClubeDto clubeObterPorId;
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
            ClubeDto clubeObterPorId;
            int IdEsperado = 001;

            //Act
            clubeObterPorId = clubeServico.ObterPorId(IdEsperado);

            //Assert
            Assert.Equal(typeof(ClubeDto), clubeObterPorId.GetType());
        }

        [Fact]
        public void DeveRetornarClubeCompletoAoObterPorId()
        {
            //Arrange
            ClubeDto clube = new(001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracanã", "Rio de Janeiro", EstadosEnum.RJ, false, null);
            int IdEsperado = 001;

            //Act
            var clubeObterPorId = clubeServico.ObterPorId(IdEsperado);

            //Assert
            Assert.Equivalent(clube, clubeObterPorId);
        }

        //CRIAR

        [Fact]
        public void DeveRetornarErrorMessageAoCriarComExcecao()
        {
            //Arrange
            List<int> elenco = new() { 12, 13, 14 };
            var clube = new Clube(0, "FC", DateTime.Parse("22-12-1950"), "Pimba Arena", EstadosEnum.TO, true, elenco);

            //Act
            var result = Assert.Throws<ValidationException>(() => clubeServico.CriarClube(clube));

            //Assert
            Assert.Contains("O nome deve ter entre 3 e 60 caracteres!", result.Message);
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
            var resultClube = database.FirstOrDefault(clube => clube.Id == IdEsperado) ?? throw new Exception("Clube inexistente!");

            //Assert
            Assert.Equivalent(clubeesperado, resultClube);
        }

        //EDITAR

        [Fact]
        public void DeveRetornarClubeCompletoAoEditar()
        {
            //Arrange
            var clubeEsperado = new Clube(001, "Mengao", DateTime.Parse("17-01-2004"), "Maracanã", EstadosEnum.GO, true, null);
            var mudancas = new Clube(001, "Mengao", DateTime.Parse("17-01-2004"), "Maracanã", EstadosEnum.GO, true, null);
            var IdDoClubeASerEditado = 1;

            //Act
            clubeServico.EditarClube(mudancas);
            var result = database.FirstOrDefault(clube => clube.Id == IdDoClubeASerEditado) ?? throw new Exception("Clube inexistente!");

           // Assert
            Assert.Equivalent(clubeEsperado, result);
        }

        [Fact]
        public void DeveRetornarExceptionAoEditar()
        {
            //Arrange
            var clubeEsperado = new Clube(001, "Mengao", DateTime.Parse("17-01-2004"), "Maracanã", EstadosEnum.GO, true, null);
            var mudancas = new Clube(001, "Fl", DateTime.Parse("17-01-2025"), "Maracanã", EstadosEnum.GO, true, null);
            var mensagemErro = "O nome deve ter entre 3 e 60 caracteres!";
            var mensagemErro2 = "A data deve ser anterior ou igual à data atual!";

            //Act
            var result = Assert.Throws<ValidationException>(() => clubeServico.EditarClube(mudancas));

            //Assert
            Assert.Contains(mensagemErro, result.Message);
            Assert.Contains(mensagemErro2, result.Message);
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
            var result = Assert.Throws<Exception>(() => database.FirstOrDefault(clube => clube.Id == idDoClubeAserRemovido) ?? throw new Exception("Clube inexistente!"));

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