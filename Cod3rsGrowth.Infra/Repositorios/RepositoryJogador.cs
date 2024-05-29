using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;



namespace Cod3rsGrowth.Test.Repositorios;

public class RepositoryJogador : IRepositoryData<Jogador>
{

    public List<Jogador> ListaJogador;
    public Jogador? jogador;


    public List<Jogador>? ObterTodos()
    {
        return ListaJogador;
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

    public void Editar(int idDoEdit, Jogador jogador)
    {
        var Editado = ObterPorId(idDoEdit);
       
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
}


