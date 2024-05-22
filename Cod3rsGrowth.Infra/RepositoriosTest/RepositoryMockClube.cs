using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;


namespace Cod3rsGrowth.Infra.RepositoriosTest
{
    public class RepositoryMockClube : IRepositoryData<Clube> 
    {
        public List<Clube> ListaDeClubes;
        public Clube? clube;
        public List<Jogador>? ListaJogadores;
        public RepositoryMockClube()
        {
            ListaDeClubes = new List<Clube>()
            {
                new (001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracanã",EstadosEnum.RJ, false,ListaJogadores)
            };
            
        }

        public List<Clube> ObterTodos()
        {
            return ListaDeClubes;
        }

        public Clube ObterPorId(int? id)
        {
           return ListaDeClubes.Find(clube => clube.Id == id);
            




        }
            
        public int? Criar(Clube clube)
        {
            clube.Id = ListaDeClubes.Any() ? ListaDeClubes.Max(clube => clube.Id) + 1 : 1;

            ListaDeClubes.Add(clube);

            return clube.Id;

        }



    }
}
