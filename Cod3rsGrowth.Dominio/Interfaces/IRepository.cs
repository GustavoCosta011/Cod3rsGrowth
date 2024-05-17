using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio;

namespace Cod3rsGrowth.Dominio.Servicos.Interfaces
{
    public interface IRepository<T>
    {
        List<T> ObterTodos();
        List<T> ObiterPorId();
        //List<T> Criar();
        //List<T> Editar();
        //List<T> Remover();

    }
}
