using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cod3rsGrowth.Dominio;

namespace Cod3rsGrowth.Test
{
    public class RepositoryMockJogador : IJogadorRepositoryMock
    {

        public List<Jogador> ObterTodos()
        {
            var jog = new List<Jogador>()
            {
                

            };

            return jog;
        }

     
    }
}

