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

    public Jogador ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public int Criar(Jogador objeto)
    {
        return database.Insert(objeto);
    }

    public void Editar(int id, Jogador objeto)
    {
        database.Jogadores
            .Where(jogador => jogador.Id == id)
            .Set(jogador => jogador.Nome, objeto.Nome)
            .Set(jogador => jogador.Idade, objeto.Idade)
            .Set(jogador => jogador.DataDeNascimento, objeto.DataDeNascimento)
            .Set(jogador => jogador.Altura, objeto.Altura)
            .Set(jogador => jogador.Peso, objeto.Peso)
            .Update();
    }

    public void Remover(int id)
    {
        throw new NotImplementedException();
    }
}


