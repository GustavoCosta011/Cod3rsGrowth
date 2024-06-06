using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra;
using System.Linq;
using LinqToDB;

namespace Cod3rsGrowth.Test.Repositorios
{
    public class RepositoryClube : IRepositoryData<Clube>
    {
        private readonly Cod3rsGrowthConnect database;

        public RepositoryClube(Cod3rsGrowthConnect Database)
        {
            database = Database;
        }

        public List<Clube> ObterTodos(string searchName)
        {
            if (searchName == null)
            {
                return database.Clubes.ToList();
            }
                return database.Clubes.Where(clube => clube.Nome.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public Clube ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public int Criar(Clube objeto)
        {
            return database.Insert(objeto);
        }

        public void Editar(int id, Clube objeto)
        {
            database.Clubes
                .Where(clube => clube.Id == id)
                .Set(clube => clube, objeto)
                .Update();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
