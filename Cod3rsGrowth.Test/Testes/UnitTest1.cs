using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Test.RepositoriosTest;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Test.Testes
{
    public class UnitTest1 : Teste
    {
        private IRepositoryClube<Clube> repositoryMockClube;

        public UnitTest1() : base()
        {
            repositoryMockClube = ServiceProvider.GetRequiredService<IRepositoryClube<Clube>>();
        }


        [Fact]
        public void Test1()
        {
            foreach(Clube x in repositoryMockClube.ObterTodos())
            {
                Console.WriteLine(x);
            }
              

        }
    }
}