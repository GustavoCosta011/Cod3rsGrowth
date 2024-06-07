using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra;
using LinqToDB;

namespace Cod3rsGrowth.Test.Repositorios;

public class RepositoryJogador : IRepositoryData<Jogador>
{
    private readonly Cod3rsGrowthConnect database;

    public RepositoryJogador(Cod3rsGrowthConnect Database)
    {
       database = Database;
    }

    public List<Jogador> ObterTodos(string searchName)
    {
        return database.Jogadores.ToList();       
    }

    public Jogador? ObterPorId(int id)
    {
        return database.Jogadores.FirstOrDefault(jogador => jogador.Id == id);
    }

    public int Criar(Jogador objeto)
    {
        return database.Insert(objeto);
    }

    public void Editar(int id, Jogador objeto)
    {
        database.Jogadores
            .Where(jogador => jogador.Id == id)
            .Set(jogador => jogador, objeto)
            .Update();
    }

    public void Remover(int id)
    {
        database.Jogadores
            .Where(jogador => jogador.Id == id)
            .Delete();
    }
}


