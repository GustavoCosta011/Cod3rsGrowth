using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Interfaces;


namespace Cod3rsGrowth.Infra.RepositoriosTest;

public class RepositoryMockJogador : IRepositoryData<Jogador> 
{

    public List<Jogador> ListaJogador;
    public Jogador jogador;

    public RepositoryMockJogador()
    {
        ListaJogador = new List<Jogador>()
        {
             new(10, "Gabi", 27, DateTime.Parse("30-08-1996"), 1.78, 68.0),
             new(11, "PedroQuexada", 25, DateTime.Parse("17-01-1998"), 1.88, 78.0),
             new(12, "Sabino", 19, DateTime.Parse("03-03-2005"), 1.70, 73.0),
             new(13, "Halandinho", 17, DateTime.Parse("30-08-2007"), 1.75, 76.0),
             new(14, "Penaldo", 33, DateTime.Parse("30-09-1991"), 1.77, 89.0),
             new(15, "Pepssi", 30, DateTime.Parse("17-10-1994"), 1.90, 77.0),
             
             

        };

    }
    public List<Jogador>? ObterTodos()
    {
        return ListaJogador;
    }

    public Jogador ObterPorId(int? id)
    {
        return ListaJogador.Find(jogador => jogador.Id == id);
    }

       
    public int? Criar(Jogador jogador)
    {
        jogador.Id = ListaJogador.Any() ? ListaJogador.Max(jogador => jogador.Id) +1 : 1;
       
        ListaJogador.Add(jogador);
        
        return jogador.Id;
        
    }
        
   




}


