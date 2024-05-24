using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Validadores;
using System.Runtime.ConstrainedExecution;
using FluentValidation;

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
        public void DeveRetornarListaNaoNulaDeJogadorAoObterTodos()
        {
            //Arrange
            List<Jogador> Lista;

            //Act
            Lista = jogadorServico.ObterTodos();

            //Assurt
            Assert.NotNull(Lista);
        }

        [Fact]
        public void DeveRetornarOTipoListaDeJogadorAoObterTodos()
        {
            //Arrange
            List<Jogador> ListaObterTodos;

            //Act
            ListaObterTodos = jogadorServico.ObterTodos();

            //Assert
            Assert.Equal(typeof(List<Jogador>), ListaObterTodos.GetType());
        }

        [Fact]
        public void DeveRetornarListaCompletaAoObterTodos()
        {
            //Arrage
            List<Jogador> Lista = new()
            {
                new(10, "Gabi", 27, DateTime.Parse("30-08-1996"), 1.78, 68.0),
                new(11, "PedroQuexada", 25, DateTime.Parse("17-01-1998"), 1.88, 78.0),
                new(12, "Sabino", 19, DateTime.Parse("03-03-2005"), 1.70, 73.0),
                new(13, "Halandinho", 17, DateTime.Parse("30-08-2007"), 1.75, 76.0),
                new(14, "Penaldo", 33, DateTime.Parse("30-09-1991"), 1.77, 89.0),
                new(15, "Pepssi", 30, DateTime.Parse("17-10-1994"), 1.90, 77.0)
            };
            //Act
            var ListaObterTodos = jogadorServico.ObterTodos();

            //ASsurt
            Assert.Equivalent(Lista, ListaObterTodos);
        }

        [Fact]
        public void DeveRetornarUmJogadorNãoNuloAoObterPorId()
        {   
            //arrange
            Jogador jogadorObterPorId;
            int IdEsperado = 015;

            //Act
            jogadorObterPorId = jogadorServico.ObterPorId(IdEsperado);

            //Assert
            Assert.NotNull(jogadorObterPorId);
        }

        [Fact]
        public void DeveRetornarTipoJogadorAoObterPorId()
        {
            //Arrange
            Jogador jogadorObterPorId;
            int IdEsperado = 015;

            //Act
            jogadorObterPorId = jogadorServico.ObterPorId(IdEsperado);
            
            //Assurt
            Assert.Equal(typeof(Jogador), jogadorObterPorId.GetType());
        }

        [Fact]
        public void DeveRetornaJogadorCompletoAoObterPorId()
        {   //Arrange
            Jogador jogador = new(15, "Pepssi", 30, DateTime.Parse("17-10-1994"), 1.90, 77.0);
            int IdEsperado = 015;

            //Act
            var jogadorObterPorId = jogadorServico.ObterPorId(IdEsperado);

            //Assurt
            Assert.Equivalent(jogador, jogadorObterPorId);
        }

        [Fact]
        public void DeveRtornarOIdDoNovoJogador()
        {   
            //Arrange
            var jogador = new Jogador(null, "ChicoMoedas", 23, DateTime.Parse("22-12-2001"), 1.70, 70.0);
            var jogadorEsperado = new Jogador(17, "ChicoMoedas", 23, DateTime.Parse("22-12-2001"), 1.70, 70.0);
            int IdEsperado = 017;

            //Act
            var result = jogadorServico.CriarJogador(jogador); 
            var jogadorCriado = jogadorServico.ObterPorId(result);

            //Assurt
            Assert.Equal(IdEsperado, result);
            Assert.Equivalent(jogadorEsperado,jogadorCriado);

        }

        [Fact]
        public void DeveRetornarErrorMessageAoCriarComExcecao()
        {
            //Arrange
            var jogador = new Jogador(null, "Hk", 35, DateTime.Parse("22-12-1989"), 1.88, 90.0);
            
            //Act
            var result = Assert.Throws<Exception>(() => jogadorServico.CriarJogador(jogador));
            
            //Assurt
            Assert.Equal("O nome tem que ter no minimo 3 e no maximo 60 letras!!",result.Message);
        }

        [Fact]
        public void DeveRetornarJogadorCompletoAoCriar()
        {

            //Arrange
            var jogadorEsperado = new Jogador(16, "Hulk", 35, DateTime.Parse("22-12-1989"), 1.88, 90.0);
            var jogador = new Jogador(null, "Hulk", 35, DateTime.Parse("22-12-1989"), 1.88, 90.0);
            int IdEsperado = 016;
            //Act
            jogadorServico.CriarJogador(jogador);
            var result =  jogadorServico.ObterPorId(IdEsperado);

            //Assert
            Assert.Equivalent(jogadorEsperado, result);
        }
    }
}