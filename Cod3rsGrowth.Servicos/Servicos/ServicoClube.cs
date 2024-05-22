using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Validadores;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.RepositoriosTest;


namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoClube : IServicoClube
    {
        private readonly IRepositoryData<Clube> repositoryMockClube;
       
        public ServicoClube(IRepositoryData<Clube> repositoryMock)
        {
            repositoryMockClube = repositoryMock;
        }
        public List<Clube> ObterTodos()
        {
            return repositoryMockClube.ObterTodos();
        }
        public Clube ObterPorId(int id)
        {
            return repositoryMockClube.ObterPorId(id);

        }
        public int? CriarClube(Clube clube)
        {
            return repositoryMockClube.Criar(clube);
        }

    
    }
}
