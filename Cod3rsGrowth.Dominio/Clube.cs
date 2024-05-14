using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Dominio
{
    public class Clube
    {
        public int Id { get; }
        public string Nome { get; }
        public DateTime Fundacao { get; set; }
        public string? Estadio { get; set; }
        public EstadosEnum Estado { get; set; }
        public bool CoberturaAntiChuva { get; set; }
        public List<Jogadores>? Elenco { get; set; }

        


    }
}
