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

    public int? Editar(int? idDoEdit, Jogador jogador)
    {
        var Editado = ObterPorId(idDoEdit);
        if (jogador.Nome != null && jogador.Nome != Editado.Nome)
        {
            Editado.Nome = jogador.Nome;
        }    
        if (jogador.Idade != null && jogador.Idade != Editado.Idade) 
        {
            Editado.Idade = jogador.Idade;
        }
        if(jogador.DataDeNascimento != Editado.DataDeNascimento)
        {
            Editado.DataDeNascimento = jogador.DataDeNascimento;
        }
        if (jogador.Altura != null && jogador.Altura != Editado.Altura )
        {
            Editado.Altura = jogador.Altura;
        }
        if (jogador.Peso != null && jogador.Peso != Editado.Peso )
        {
            Editado.Peso = jogador.Peso;
        }

        return Editado.Id;





    }
}


