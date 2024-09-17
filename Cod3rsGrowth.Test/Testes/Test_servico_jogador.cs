using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Infra;
using FluentValidation;
using FluentValidation.Results;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Cod3rsGrowth.Test.Testes
{
    public class Test_servico_jogador : Teste
    {
        private readonly ServicoJogador jogadorServico;
        private readonly Cod3rsGrowthConnect database;

        public Test_servico_jogador() : base()
        {
            jogadorServico = _serviceProvider.GetRequiredService<ServicoJogador>();
            database = _serviceProvider.GetRequiredService<Cod3rsGrowthConnect>();
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

        [Fact]
        public void DeveRetornarListaCompletaAoObterTodos()
        {
            // Arrange
            var listaEsperada = new List<Jogador>
            {
                new Jogador(3, "Junior Alonso", 1, "Atlético Mineiro", 28, DateTime.Parse("1993-02-09"), 1.84, 79)
            };

            // Act
            var listaObtida = jogadorServico.ObterTodos(null);

            // Assert
            Assert.Contains(listaEsperada[0], listaObtida);
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
            Assert.Equal(jogadorEsperado, jogadorObtido);
        }

        // CRIAR

        [Fact]
        public void DeveRetornarOIdDoNovoJogador()
        {
            // Arrange
            var jogador = new Jogador(0, "Adilson Goiano", 20, "Grêmio Novorizontino", 33, DateTime.Parse("1987-08-21"), 1.78, 74);
            int idEsperado = 216;

            // Act
            int idCriado = jogadorServico.CriarJogador(jogador);
            var jogadorCriado = database.Jogadores.FirstOrDefault(j => j.Id == idEsperado) ?? throw new Exception("Jogador inexistente!");

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
            Assert.Contains("O nome tem que ter no minimo 3 e no maximo 60 letras!!", result.Message);
        }

        [Fact]
        public void DeveRetornarJogadorCompletoAoCriar()
        {
            // Arrange
            var jogador = new Jogador(0, "Chik", 1, "Atlético Mineiro", 35, DateTime.Parse("1989-12-22"), 1.88, 90);
            int idEsperado = 216;

            // Act
            jogadorServico.CriarJogador(jogador);
            var jogadorCriado = database.Jogadores.FirstOrDefault(j => j.Id == idEsperado) ?? throw new Exception("Jogador inexistente!");

            // Assert
            Assert.Equal(jogador, jogadorCriado);
        }

        // EDITAR

        [Fact]
        public void DeveRetornarJogadorCompletoAoEditar()
        {
            // Arrange
            var jogadorEsperado = new Jogador(11, "Pedro", null, null, 25, DateTime.Parse("1998-01-17"), 1.88, 78.0);
            var mudancas = new Jogador(11, "Pedro", null, null, 25, DateTime.Parse("1998-01-17"), 1.88, 78.0);

            // Act
            jogadorServico.EditarJogador(mudancas);
            var jogadorObtido = database.Jogadores.FirstOrDefault(j => j.Id == 11) ?? throw new Exception("Jogador inexistente!");

            // Assert
            Assert.Equal(jogadorEsperado, jogadorObtido);
        }

        [Fact]
        public void DeveRetornarExceptionAoEditar()
        {
            // Arrange
            var mudancas = new Jogador(11, "Pe", null, null, 33, DateTime.Parse("1998-01-17"), null, null);
            var mensagemErro = "O nome tem que ter no minimo 3 e no maximo 60 letras!!\nIdade incoerente a data de nascimento!!";

            // Act
            var result = Assert.Throws<ValidationException>(() => jogadorServico.EditarJogador(mudancas));

            // Assert
            Assert.Equal(mensagemErro, result.Message);
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
            var result = Assert.Throws<Exception>(() => database.Jogadores.FirstOrDefault(j => j.Id == idDoJogadorAserRemovido) ?? throw new Exception("Jogador inexistente!"));

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
