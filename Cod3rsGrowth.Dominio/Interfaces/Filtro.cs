using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public class Filtro
    {
        public string? Nome { get; set; }
        public int? IdClube { get; set; }
        public DateTime? DataPiso { get; set; }
        public DateTime? DataTeto { get; set; }
        public EstadosEnum? Estado { get; set; }
    }
}
