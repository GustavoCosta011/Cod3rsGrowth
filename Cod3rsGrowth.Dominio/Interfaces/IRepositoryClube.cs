using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IRepositoryClube<T> where T : class
    {
        List<T> ObterTodos();
        T ObterPorId(int id);
        T Criar(int id, string nome, DateTime fundacao, string? estadio, EstadosEnum estado, bool coberturaAntiChuva, List<Jogador>? elenco);
        //T Editar();
        //T Remover();

    }
}
