using Cod3rsGrowth.Infra;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;

namespace Cod3rsGrowth.Test.Testes
{
    public class TestConexao : Teste
    {
        private readonly Cod3rsGrowthConnect DbConexao;
        public TestConexao() : base() 
        {
            DbConexao = ServiceProvider.GetRequiredService<Cod3rsGrowthConnect>();
        }

        //OBTER TODOS

        [Fact]
        public void DeveRetornarConexao()
        {
                bool ConexaoOn = DbConexao.Connection.State == System.Data.ConnectionState.Open;

                Assert.True(ConexaoOn, "A conexao está ON");  
        }
    }
}
