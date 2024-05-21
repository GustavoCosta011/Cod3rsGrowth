using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.RepositoriosTest;


namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoClube : IServicoClube<Clube>
    {
        private  RepositoryMockClube? repositoryMockClube;
        public ServicoClube(RepositoryMockClube repositoryMock)
        {
            repositoryMockClube = repositoryMock;
        }

        
        public Clube CriarClube(Clube clube)
        {
            return repositoryMockClube.Criar(clube);
        }

        public List<Clube> ObterTodos()
        {
            return repositoryMockClube.ObterTodos();
        }
    }
}
