using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IFiltro
    {
        string? Nome { get; set; }
        int? IdClube { get; set; }
        DateTime? DataPiso { get; set; }
        DateTime? DataTeto { get; set; }
        EstadosEnum? Estado { get; set; }
    }
}
