using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra;

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

    public Jogador ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public int Criar(Jogador objeto)
    {
        throw new NotImplementedException();
    }

    public void Editar(int id, Jogador objeto)
    {
        throw new NotImplementedException();
    }

    public void Remover(int id)
    {
        throw new NotImplementedException();
    }
}


