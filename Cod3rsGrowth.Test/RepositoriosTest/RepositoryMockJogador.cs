using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Servicos.Interfaces;

namespace Cod3rsGrowth.Test.Repositorios
{
    public class RepositoryMockJogador : IRepository<Jogador>
    {

        public List<Jogador> ListaJogador;
        public List<Jogador> ObterTodos()
        {
            new Jogador(010, "Gabi", 27, DateTime.Parse("30-08-1996"), 1.78, 68.0);



            return ListaJogador;
        }

        public RepositoryMockJogador()
        {
            ListaJogador = new List<Jogador>()
            {Gabi

            };

        }


    }
}

