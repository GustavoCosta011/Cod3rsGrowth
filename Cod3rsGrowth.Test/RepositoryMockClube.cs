using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio;

namespace Cod3rsGrowth.Test
{
    public class RepositoryMockClube : IRepository<Clube>
    {

        public List<Clube> ObterTodos()
        {
            var club = new List<Clube>()
            {

            };
      

            return club;
        }
    }
}
