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

        public List<Clube> ObterTodos(IFiltro filtro)
        {
            var clubes = database.Clubes.AsQueryable();

            if (filtro.No) { }
        }

        public Clube? ObterPorId(int id)
        {
            return database.Clubes.FirstOrDefault(clube => clube.Id == id);
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
            database.Clubes
                .Where(clube => clube.Id == id)
                .Delete();
        }
    }
}
