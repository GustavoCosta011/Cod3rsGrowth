using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Test.Repositorios
{
    public class RepositoryMockJogador : IRepository<Jogador>
    {

        public List<Jogador> ListaJogador;
        public List<Jogador> ObterTodos()
        {




            return ListaJogador;
        }

        public RepositoryMockJogador()
        {
            ListaJogador = new List<Jogador>()
            {

            };

        }


    }
}

