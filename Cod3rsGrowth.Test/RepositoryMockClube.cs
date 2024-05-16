using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio;

namespace Cod3rsGrowth.Test
{
    public class RepositoryMockClube : IClubeRepositoryMock
    {

        public List<Clube> IObterTodos()
        {
            new(001, "Flamengo", 15 / 11 / 1895, "Maracanã", EstadosEnum.RJ, false, );





            return new List<Clube>();
        }
    }
}
