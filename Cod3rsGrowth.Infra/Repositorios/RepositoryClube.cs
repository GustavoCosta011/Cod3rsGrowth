using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Test.Repositorios
{
    public class RepositoryClube : IRepositoryData<Clube>
    {
        public int Criar(Clube objeto)
        {
            throw new NotImplementedException();
        }

        public void Editar(int id, Clube objeto)
        {
            throw new NotImplementedException();
        }

        public Clube ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Clube> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
