using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Test.Singletons.Singleton;


namespace Cod3rsGrowth.Test.Testes
{
    public class Test_servico_jogador : Teste
    {
        private readonly ServicoJogador jogadorServico;
        private readonly List<Jogador> jogadorList = ClasseSingleton.Instance.Jogadores;
       
        public Test_servico_jogador() : base()
        {
             jogadorServico = ServiceProvider.GetRequiredService<ServicoJogador>();
        }

//OBTER TODOS

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
                     new(13, "Halandinho", 17, DateTime.Parse("30-08-2007"), 1.75, 76.0),
                     new(14, "Penaldo", 33, DateTime.Parse("30-09-1991"), 1.77, 89.0),
                     new(15, "Pepssi", 30, DateTime.Parse("17-10-1994"), 1.90, 77.0),
            };
            //Act
            var ListaObterTodos = jogadorServico.ObterTodos();

            //Assert
            Assert.Equivalent(Lista, ListaObterTodos);
        }

//OBTER POR ID

        [Fact]
        public void DeveRetornarUmJogadorN„oNuloAoObterPorId()
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
            
            //Assert
            Assert.Equal(typeof(Jogador), jogadorObterPorId.GetType());
        }

        [Fact]
        public void DeveRetornaJogadorCompletoAoObterPorId()
        {   //Arrange
            Jogador jogador = new(15, "Pepssi", 30, DateTime.Parse("17-10-1994"), 1.90, 77.0);
            int IdEsperado = 015;

            //Act
            var jogadorObterPorId = jogadorServico.ObterPorId(IdEsperado);

            //Assert
            Assert.Equivalent(jogador, jogadorObterPorId);
        }

//CRIAR

        [Fact]
        public void DeveRtornarOIdDoNovoJogador()
        {   
            //Arrange
            var jogador = new Jogador(0, "ChicoMoedas", 23, DateTime.Parse("22-12-2001"), 1.70, 70.0);
            var jogadorEsperado = new Jogador(17, "ChicoMoedas", 23, DateTime.Parse("22-12-2001"), 1.70, 70.0);
            int IdEsperado = 017;

            //Act
            int result = jogadorServico.CriarJogador(jogador); 
            var jogadorCriado = jogadorList.Find(clube => clube.Id == IdEsperado) ?? throw new Exception("Jogador inexistente!");

            //Assert
            Assert.Equal(IdEsperado, result);
            Assert.Equivalent(jogadorEsperado,jogadorCriado);

        }

        [Fact]
        public void DeveRetornarErrorMessageAoCriarComExcecao()
        {
            //Arrange
            var jogador = new Jogador(0, "Hk", 35, DateTime.Parse("22-12-1989"), 1.88, 90.0);
            
            //Act
            var result = Assert.Throws<Exception>(() => jogadorServico.CriarJogador(jogador));
            
            //Assert
            Assert.Equal("O nome tem que ter no minimo 3 e no maximo 60 letras!!",result.Message);
        }

        [Fact]
        public void DeveRetornarJogadorCompletoAoCriar()
        {

            //Arrange
            var jogadorEsperado = new Jogador(16, "Hulk", 35, DateTime.Parse("22-12-1989"), 1.88, 90.0);
            var jogador = new Jogador(0, "Hulk", 35, DateTime.Parse("22-12-1989"), 1.88, 90.0);
            int IdEsperado = 016;

            //Act
            jogadorServico.CriarJogador(jogador);
            var result = jogadorList.Find(clube => clube.Id == IdEsperado) ?? throw new Exception("Jogador inexistente!");

            //Assert
            Assert.Equivalent(jogadorEsperado, result);
        }

//EDITAR

        [Fact]
        public void DeveRetornarJogadorOCmpletoAoEditar()
        {
            //Arrange
            var jogadorEsperado = new Jogador(11, "Pedro", 25, DateTime.Parse("17-01-1998"), 1.88, 78.0);
            var mudancas = new Jogador(0, "Pedro", 25, DateTime.Parse("17-01-1998"),1.88,78.0);
            var IdDoJogadorASerEditado = 11;

            //Act
            jogadorServico.EditarJogador(IdDoJogadorASerEditado, mudancas);
            var result = jogadorList.Find(clube => clube.Id == IdDoJogadorASerEditado) ?? throw new Exception("Jogador inexistente!");

            //Assert
            Assert.Equivalent(jogadorEsperado, result);
        }

        [Fact]
        public void DeveRetornarExceptionAoEditar()
        {
            //Arrange
            var jogadorEsperado = new Jogador(11, "Pedro", 25, DateTime.Parse("17-01-1998"), 1.88, 78.0);
            var mudancas = new Jogador(0, "Pe", 33, DateTime.Parse("17-01-1998"), null, null);
            var IdDoJogadorASerEditado = 11;
            var mensagemErro = "O nome tem que ter no minimo 3 e no maximo 60 letras!!" +
                "Idade incoerente a data de nascimento!!";
            
            //Act
            var result = Assert.Throws<Exception>(() => jogadorServico.EditarJogador(IdDoJogadorASerEditado, mudancas));

            //Assert
            Assert.Equal(mensagemErro, result.Message);
             
        }


//REMOVER

        [Fact]
        public void DeveRetornarJogadorFoiRemovido()

        {
            //Arrange
            var idDoJogadorAserRemovido = 12;
            var menssagemErro = "Jogador inexistente!";

            //Act
            jogadorServico.RemoverJogador(idDoJogadorAserRemovido);
            var result =  Assert.Throws<Exception>(() => jogadorList.Find(clube => clube.Id == idDoJogadorAserRemovido) ?? throw new Exception("Jogador inexistente!"));

            //Assert
            Assert.Equal(menssagemErro,result.Message);

        }

        [Fact]
        public void DeveRetornarExceptionAoRemoverJogador()

        {
            //Arrange
            var idDoJogadorAserRemovido = 22;
            var mensagemErro = "Jogador inexistente!";

            //Act
            var result = Assert.Throws<Exception>(() => jogadorServico.RemoverJogador(idDoJogadorAserRemovido));

            //Assert
            Assert.Equal(mensagemErro, result.Message);

        }
    }
}