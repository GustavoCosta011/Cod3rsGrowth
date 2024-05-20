using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositoryJogador<T> where T : class
    {
        T ObterPorId(int id);
        T Criar(Jogador y);
        //T Editar();
        //T Remover();

    }
}
