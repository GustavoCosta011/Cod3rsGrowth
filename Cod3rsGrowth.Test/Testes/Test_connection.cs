
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Test.Singletons.Singleton;
using LinqToDB.Data;
using Microsoft.Extensions.DependencyInjection;


namespace Cod3rsGrowth.Test.Testes
{
    public class TestConexao : Teste
    {
        public TestConexao() : base() { }

        //OBTER TODOS

        [Fact]
        public void DeveRetornarConexao()
        {
            Cod3rsGrowthConnect? Database = null;

            try
            {
                Database = Cod3rsGrowthConnect.Connect("Cod3rsGrowthDb");
                bool ConexaoOn = Database.Connection.State == System.Data.ConnectionState.Open;

                Assert.True(ConexaoOn, "A conexao está ON");

            }
            catch
            {
                Database?.Dispose();
            }
        }
    }
}
