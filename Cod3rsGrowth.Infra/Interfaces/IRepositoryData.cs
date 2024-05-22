using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Infra.Interfaces
{
    public interface IRepositoryData<T> where T : class
    {
        List<T> ObterTodos();
        int Criar(T objeto);
        T ObterPorId(int id);

    }

}


