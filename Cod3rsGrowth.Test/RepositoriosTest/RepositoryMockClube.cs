using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Test.RepositoriosTest
{
    public class RepositoryMockClube : IRepository<Clube>
    {
        public List<Clube> ListaDeClubes;
        public Clube clube;
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

        public Clube ObterPorId(int id)
        {

            foreach (Clube clube in ListaDeClubes)
            {
                if (clube.Id == id)
                {
                    continue;
                }

            }

            return clube;
        }
        public Clube Criar(Clube x)
        {
            x.Id = 5;
            x.Nome = "PimbaFC";
            x.Fundacao = DateTime.Parse("24-11-2008");
            x.Estadio = "Arena Pimbador";
            x.Estado = EstadosEnum.GO;
            x.CoberturaAntiChuva = false;
            x.Elenco = new List<Jogador>()
            {
                new(10, "Emibape", 22, DateTime.Parse("23-08-2002"), 1.80, 80.0)
            };
            ListaDeClubes.Add(x);


            return x;
        }


    }
}
