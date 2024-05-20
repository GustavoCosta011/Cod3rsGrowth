using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositoryJogador<T> where T : class
    {
        List<T> ObterTodos();
        T ObterPorId(int id);
        T Criar(int id, string nome, int idade, DateTime dataDeNascimento, double altura, double peso);
        //T Editar();
        //T Remover();

    }
}
