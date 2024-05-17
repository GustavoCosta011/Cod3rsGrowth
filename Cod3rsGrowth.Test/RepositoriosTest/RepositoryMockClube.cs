using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Servicos.Interfaces;

namespace Cod3rsGrowth.Test.Repositorios
{
    public class RepositoryMockClube : IRepository<Clube>
    {
        public List<Clube> ListaDeClubes;
        public List<Clube> ObterTodos()
        {
            Clube Flamengo = new(001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracanã", false, RepositoryMockJogador.ObterTodos(Flamengo));
;



            return ListaDeClubes;
        }

        public List<Clube>? ObiterPorId(int id)
        {
            var clube = ListaDeClubes.Find(clube  => clube.Id == id);
            if (clube == null)
            {
                return clube;
            }    
               
        }

        public RepositoryMockClube()
        {
            ListaDeClubes = new List<Clube>()
            {

            };

        }
    }
}
