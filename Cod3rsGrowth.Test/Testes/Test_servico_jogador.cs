using Cod3rsGrowth.Dominio.Modelos;
using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Test.Singletons.Singleton;
using Cod3rsGrowth.Infra;
using static LinqToDB.Sql;


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

//OBTER TODOS

        [Fact]
        public void DeveRetornarListaNaoNulaDeJogadorAoObterTodos()
        {
            //Arrange
            List<Jogador> Lista;

            //Act
            Lista = jogadorServico.ObterTodos(null);

            //Assurt
            Assert.NotNull(Lista);
        }

        [Fact]
        public void DeveRetornarOTipoListaDeJogadorAoObterTodos()
        {
            //Arrange
            List<Jogador> ListaObterTodos;

            //Act
            ListaObterTodos = jogadorServico.ObterTodos(null);

            //Assert
            Assert.Equal(typeof(List<Jogador>), ListaObterTodos.GetType());
        }

        [Fact]
        public void DeveRetornarListaCompletaAoObterTodos()
        {
            //Arrage
            List<Jogador> Lista = new()
            {
                        new( 2, "Everson",1  , "Atlético Mineiro", 32, DateTime.Parse("22-07-1988"), 1.92, 82),
                        new( 3, "Mariano", 1 , "Atlético Mineiro", 34,  DateTime.Parse("1986 - 06 - 23"), 1.79 , 73)
            };
            //Act
            var ListaObterTodos = jogadorServico.ObterTodos(null);

            //Assert
            Assert.Equivalent(Lista, ListaObterTodos);
        }

//OBTER POR ID

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
            
            //Assert
            Assert.Equal(typeof(Jogador), jogadorObterPorId.GetType());
        }

        [Fact]
        public void DeveRetornaJogadorCompletoAoObterPorId()
        {   //Arrange
            Jogador jogador = new(132, "Vinícius Lopes",  12,  "Goiás",   22,  DateTime.Parse("07-04-1999"), 1.8, 75);
            int IdEsperado = 132;

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
            var jogador = new Jogador(216, "Adilson Goiano",  20, "Grêmio Novorizontino", 33, DateTime.Parse("21-08-1987") , 1.78, 74);
            var jogadorEsperado = new Jogador(216, "Adilson Goi", 20, "Grêmio Novorizontino", 33, DateTime.Parse("21-08-1987"), 1.78, 74);
            int IdEsperado = 017;

            //Act
            int result = jogadorServico.CriarJogador(jogador); 
            var jogadorCriado = database.Jogadores.FirstOrDefault(clube => clube.Id == IdEsperado) ?? throw new Exception("Jogador inexistente!");

            //Assert
            Assert.Equal(IdEsperado, result);
            Assert.Equivalent(jogadorEsperado,jogadorCriado);

        }

        [Fact]
        public void DeveRetornarErrorMessageAoCriarComExcecao()
        {
            //Arrange
            var jogador = new Jogador(157, "M",15, "Palmeiras",32,DateTime.Parse("11-12-1988"), 1.77, 70);
            
            //Act
            var result = Assert.Throws<Exception>(() => jogadorServico.CriarJogador(jogador));
            
            //Assert
            Assert.Equal("O nome tem que ter no minimo 3 e no maximo 60 letras!!",result.Message);
        }

        [Fact]
        public void DeveRetornarJogadorCompletoAoCriar()
        {

            //Arrange
            var jogadorEsperado = database.Jogadores.
            var jogador = new Jogador( "Chik", 1, "Atlético Mineiro", 35, DateTime.Parse("22-12-1989"), 1.88, 90.0);
            int IdEsperado = 016;

            //Act
            jogadorServico.CriarJogador(jogador);
            var result = database.Jogadores.FirstOrDefault(clube => clube.Id == IdEsperado) ?? throw new Exception("Jogador inexistente!");

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
            var result = database.Jogadores.FirstOrDefault(clube => clube.Id == IdDoJogadorASerEditado) ?? throw new Exception("Jogador inexistente!");

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
            var result =  Assert.Throws<Exception>(() => database.Jogadores.FirstOrDefault(clube => clube.Id == idDoJogadorAserRemovido) ?? throw new Exception("Jogador inexistente!"));

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