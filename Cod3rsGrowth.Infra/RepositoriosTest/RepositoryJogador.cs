using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons.Testes.Singleton;


namespace Cod3rsGrowth.Infra.RepositoriosTest;

public class RepositoryJogador : IRepositoryData<Jogador>
{

    public List<Jogador> ListaJogador = ClasseSingleton.Instance.Jogadores;
    public Jogador? jogador;


    public List<Jogador>? ObterTodos()
    {
        return ListaJogador;
    }

    public Jogador ObterPorId(int? id)
    {
        return ListaJogador.Find(jogador => jogador.Id == id) ?? throw new Exception("Jogador inexistente!");
    }

    public int? Criar(Jogador jogador)
    {
        int IncremntoCriar = 1;
        jogador.Id = ListaJogador.Any() ? ListaJogador.Max(jogador => jogador.Id) + IncremntoCriar : IncremntoCriar;

        ListaJogador.Add(jogador);

        return jogador.Id;

    }

    public void Editar(int? idDoEdit, Jogador jogador)
    {
        var Editado = ObterPorId(idDoEdit);
       
            Editado.Nome = jogador.Nome;

            Editado.Idade = jogador.Idade;
        
            Editado.DataDeNascimento = jogador.DataDeNascimento;

            Editado.Altura = jogador.Altura;

            Editado.Peso = jogador.Peso;

    }

    public void Remover(int? id)
    {
        throw new NotImplementedException();
    }
}


