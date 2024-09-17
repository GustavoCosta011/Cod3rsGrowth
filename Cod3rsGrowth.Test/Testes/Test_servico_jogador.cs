using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Infra;
using FluentValidation;
using Cod3rsGrowth.Test.Singletons.Singleton;

namespace Cod3rsGrowth.Test.Testes
{
    public class Test_servico_jogador : Teste
    {
        private readonly ServicoJogador jogadorServico;
        private readonly List<Jogador> database;

        public Test_servico_jogador() : base()
        {
            jogadorServico = _serviceProvider.GetRequiredService<ServicoJogador>();
            database = ClasseSingleton.Instance.Jogadores;
        }

        // OBTER TODOS

        [Fact]
        public void DeveRetornarListaNaoNulaDeJogadorAoObterTodos()
        {
            // Act
            var lista = jogadorServico.ObterTodos(null);

            // Assert
            Assert.NotNull(lista);
        }

        [Fact]
        public void DeveRetornarOTipoListaDeJogadorAoObterTodos()
        {
            // Act
            var lista = jogadorServico.ObterTodos(null);

            // Assert
            Assert.IsType<List<Jogador>>(lista);
        }

        // OBTER POR ID

        [Fact]
        public void DeveRetornarUmJogadorNaoNuloAoObterPorId()
        {
            // Arrange
            int idEsperado = 15;

            // Act
            var jogador = jogadorServico.ObterPorId(idEsperado);

            // Assert
            Assert.NotNull(jogador);
        }

        [Fact]
        public void DeveRetornarTipoJogadorAoObterPorId()
        {
            // Arrange
            int idEsperado = 15;

            // Act
            var jogador = jogadorServico.ObterPorId(idEsperado);

            // Assert
            Assert.IsType<Jogador>(jogador);
        }

        [Fact]
        public void DeveRetornarJogadorCompletoAoObterPorId()
        {
            // Arrange
            var jogadorEsperado = new Jogador(132, "Vinícius Lopes", 12, "Goiás", 22, DateTime.Parse("1999-04-07"), 1.8, 75);
            int idEsperado = 132;

            // Act
            var jogadorObtido = jogadorServico.ObterPorId(idEsperado);

            // Assert
            Assert.Equivalent(jogadorEsperado, jogadorObtido);
        }

        // CRIAR

        [Fact]
        public void DeveRetornarOIdDoNovoJogador()
        {
            // Arrange
            var jogador = new Jogador(0, "Adilson Goiano", 20, "Grêmio Novorizontino", 33, DateTime.Parse("1987-08-21"), 1.78, 74);
            int idEsperado = 134;

            // Act
            int idCriado = jogadorServico.CriarJogador(jogador);
            var jogadorCriado = database.FirstOrDefault(j => j.Id == idEsperado) ?? throw new Exception("Jogador inexistente!");

            // Assert
            Assert.Equal(idEsperado, idCriado);
            Assert.Equal(jogador, jogadorCriado);
        }

        [Fact]
        public void DeveRetornarErrorMessageAoCriarComExcecao()
        {
            // Arrange
            var jogador = new Jogador(0, "M", 15, "Palmeiras", 32, DateTime.Parse("1988-12-11"), 1.77, 70);

            // Act
            var result = Assert.Throws<ValidationException>(() => jogadorServico.CriarJogador(jogador));

            // Assert
            Assert.Contains("O nome deve ter entre 3 e 60 caracteres!", result.Message);
        }

        [Fact]
        public void DeveRetornarJogadorCompletoAoCriar()
        {
            // Arrange
            var jogador = new Jogador(0, "Chik", 1, "Atlético Mineiro", 35, DateTime.Parse("1989-12-22"), 1.88, 90);

            // Act
            int idEsperado = jogadorServico.CriarJogador(jogador);
            var jogadorCriado = database.FirstOrDefault(j => j.Id == idEsperado) ?? throw new Exception("Jogador inexistente!");

            // Assert
            Assert.Equal(jogador, jogadorCriado);
        }

        // EDITAR

        [Fact]
        public void DeveRetornarJogadorCompletoAoEditar()
        {
            // Arrange
            var jogadorEsperado = new Jogador(13, "dinho", 002, "FC Rondonia", 17, DateTime.Parse("30-08-2007"), 1.75, 76.0);
            var mudancas = new Jogador(13, "dinho", 002, "FC Rondonia", 17, DateTime.Parse("30-08-2007"), 1.75, 76.0);

            // Act
            jogadorServico.EditarJogador(mudancas);
            var jogadorObtido = database.FirstOrDefault(j => j.Id == 13) ?? throw new Exception("Jogador inexistente!");

            // Assert
            Assert.Equivalent(jogadorEsperado, jogadorObtido);
        }

        [Fact]
        public void DeveRetornarExceptionAoEditar()
        {
            // Arrange
            var mudancas = new Jogador(11, "Pe", 1, "Flamengo", 33, DateTime.Parse("1998-01-17"), null, null);
            var mensagemErro1 = "O nome deve ter entre 3 e 60 caracteres!";
            var mensagemErro2 = "Campo editado 'Altura' não pode ser alterado para vazio!";
            var mensagemErro3 = "Campo editado 'Peso' não pode ser alterado para vazio!";

            // Act
            var result = Assert.Throws<ValidationException>(() => jogadorServico.EditarJogador(mudancas));

            // Assert
            Assert.Contains(mensagemErro1, result.Message);
            Assert.Contains(mensagemErro2, result.Message);
            Assert.Contains(mensagemErro3, result.Message);
        }

        // REMOVER

        [Fact]
        public void DeveRetornarJogadorFoiRemovido()
        {
            // Arrange
            int idDoJogadorAserRemovido = 12;
            var mensagemErro = "Jogador inexistente!";

            // Act
            jogadorServico.RemoverJogador(idDoJogadorAserRemovido);
            var result = Assert.Throws<Exception>(() => database.FirstOrDefault(j => j.Id == idDoJogadorAserRemovido) ?? throw new Exception("Jogador inexistente!"));

            // Assert
            Assert.Equal(mensagemErro, result.Message);
        }

        [Fact]
        public void DeveRetornarExceptionAoRemoverJogador()
        {
            // Arrange
            int idDoJogadorAserRemovido = 22;
            var mensagemErro = "Jogador inexistente!";

            // Act
            var result = Assert.Throws<Exception>(() => jogadorServico.RemoverJogador(idDoJogadorAserRemovido));

            // Assert
            Assert.Equal(mensagemErro, result.Message);
        }
    }
}
