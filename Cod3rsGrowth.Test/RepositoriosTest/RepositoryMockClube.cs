using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Test.Repositorios
{
    public class RepositoryMockClube : IRepository<Clube>
    {
        public List<Clube> ListaDeClubes;
        public List<Clube> ObterTodos()
        {




            return ListaDeClubes;
        }

        public RepositoryMockClube()
        {
            ListaDeClubes = new List<Clube>()
            {

            };

        }
    }
}
