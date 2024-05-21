using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.RepositoriosTest;


namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoClube : IServicoClube<Clube>
    {
        private readonly IRepositoryData<Clube> repositoryMockClube;
        private Clube? club;

        public ServicoClube(IRepositoryData<Clube> repositoryMock)
        {
            repositoryMockClube = repositoryMock;
        }

        
        public Clube CriarClube(Clube clube)
        {
            return repositoryMockClube.Criar(clube);
        }

        public Clube ObterPorId(int id)
        {
            foreach (Clube clube in repositoryMockClube.ObterTodos())
                {
                    if (clube.Id == id)
                    {
                    club = clube;
                    break;
                    }
                }

            return club;
            
        }

        public List<Clube> ObterTodos()
        {
            return repositoryMockClube.ObterTodos();
        }
    }
}
