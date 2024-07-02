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

    public List<Jogador> ObterTodos(Filtro filtro)
    {
        if (filtro == null) return database.Jogadores.ToList();
        var jogadores = database.Jogadores.AsQueryable();

        if (!string.IsNullOrEmpty(filtro.Nome)) jogadores = jogadores.Where(jogador => jogador.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrEmpty(filtro.Clube)) jogadores = jogadores.Where(jogador => jogador.Clube.Contains(filtro.Clube, StringComparison.OrdinalIgnoreCase));
        if (filtro.DataPiso.HasValue) jogadores = jogadores.Where(jogador => jogador.DataDeNascimento >= filtro.DataPiso);
        if (filtro.DataTeto.HasValue) jogadores = jogadores.Where(jogador => jogador.DataDeNascimento <= filtro.DataTeto);

        return jogadores.ToList();
    }

    public Jogador? ObterPorId(int id)
    {
        return database.Jogadores.FirstOrDefault(jogador => jogador.Id == id);
    }

    public int Criar(Jogador objeto)
    {
        return database.InsertWithInt32Identity(objeto);
    }

    public void Editar(Jogador objeto)
    {
        database.Update(objeto);
    }

    public void Remover(int id)
    {
        database.Jogadores
            .Where(jogador => jogador.Id == id)
            .Delete();
    }
}


