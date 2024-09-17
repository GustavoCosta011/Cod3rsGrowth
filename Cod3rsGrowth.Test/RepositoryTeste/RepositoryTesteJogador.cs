using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Test.Singletons.Singleton;


namespace Cod3rsGrowth.Test.RepositoriosTeste;

public class RepositoryTesteJogador : IRepositoryData<Jogador>
{

    public List<Jogador> ListaJogador = ClasseSingleton.Instance.Jogadores;
    public Jogador? jogador;


    public List<Jogador>? ObterTodos(Filtro? filtro)
    {
        if (filtro == null) return ListaJogador;
        var jogadores = ListaJogador.AsQueryable();

        if (!string.IsNullOrEmpty(filtro.Nome)) jogadores = jogadores.Where(jogador => jogador.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrEmpty(filtro.Clube)) jogadores = jogadores.Where(jogador => jogador.Clube.Contains(filtro.Clube, StringComparison.OrdinalIgnoreCase));
        if (filtro.DataPiso.HasValue) jogadores = jogadores.Where(jogador => jogador.DataDeNascimento >= filtro.DataPiso);
        if (filtro.DataTeto.HasValue) jogadores = jogadores.Where(jogador => jogador.DataDeNascimento <= filtro.DataTeto);

        return jogadores.ToList();
    }

    public Jogador ObterPorId(int id)
    {
        return ListaJogador.Find(jogador => jogador.Id == id) ?? throw new Exception("Jogador inexistente!");
    }

    public int Criar(Jogador jogador)
    {
        int IncremntoCriar = 1;
        jogador.Id = ListaJogador.Any() ? ListaJogador.Max(jogador => jogador.Id) + IncremntoCriar : IncremntoCriar;

        ListaJogador.Add(jogador);

        return jogador.Id;

    }

    public void Editar(Jogador jogador)
    {
        var Editado = ObterPorId(jogador.Id);

        Editado.Nome = jogador.Nome;

        Editado.Idade = jogador.Idade;

        Editado.DataDeNascimento = jogador.DataDeNascimento;

        Editado.Altura = jogador.Altura;

        Editado.Peso = jogador.Peso;

    }

    public void Remover(int id)

    {
        var jogadorARemover = ObterPorId(id);
        ListaJogador.Remove(jogadorARemover);
    }

    public List<Jogador> ObterTodos(string serch)
    {
        throw new NotImplementedException();
    }
}