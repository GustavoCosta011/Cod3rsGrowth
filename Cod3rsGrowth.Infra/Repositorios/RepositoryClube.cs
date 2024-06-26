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

        public List<Clube> ObterTodos(Filtro? filtro)
        {
            if (filtro == null) return database.Clubes.ToList();
            var clubes = database.Clubes.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nome)) clubes = clubes.Where(clube => clube.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));
            if (filtro.Estado.HasValue) clubes = clubes.Where(clube => clube.Estado == filtro.Estado);
            if (filtro.DataPiso.HasValue) clubes = clubes.Where(clube => clube.Fundacao >= filtro.DataPiso);
            if (filtro.DataTeto.HasValue) clubes = clubes.Where(clube => clube.Fundacao <= filtro.DataTeto);

            return clubes.ToList();
        }

        public Clube? ObterPorId(int id)
        {
            return database.Clubes.FirstOrDefault(clube => clube.Id == id);
        }

        public int Criar(Clube objeto)
        {
            return database.Insert(objeto);
        }

        public void Editar(Clube objeto)
        {
            database.Update(objeto);
            database.Jogadores.Where(jogador => jogador.IdClube == objeto.Id)
                .Set(jogador => jogador.Clube, objeto.Nome)
                .Update();
        }


        public void Remover(int id)
        {            
            string nomeClube = ObterPorId(id).Nome;
            string Vazio = "";
            database.Clubes
                .Where(clube => clube.Id == id)
                .Delete();
            database.Jogadores.Where(jogador => jogador.Clube == nomeClube)
                .Set(jogador => jogador.Clube, Vazio)
                .Update();
        }
    }
}
