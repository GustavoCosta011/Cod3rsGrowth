using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.RepositoriosTest;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public interface IServicos<T> where T : class
    {
        T ObterTodos()
        {
            return RepositoryMockJogador.ObterTodos();
        }
        T Criar(T objeto);
        T ObterPorId(int id);


        //T Editar();
        //T Remover();

    }

}


