using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Dominio.Modelos
{
    public class Clube
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public DateTime Fundacao { get; set; }
        public string? Estadio { get; set; }
        public EstadosEnum Estado { get; set; }
        public bool CoberturaAntiChuva { get; set; }
        public List<int>? Elenco { get; set; }

        public Clube(int? id, string nome, DateTime fundacao, string? estadio, EstadosEnum estado, bool coberturaAntiChuva, List<int>? elenco)
        {
            Id = id;
            Nome = nome;
            Fundacao = fundacao;
            Estadio = estadio;
            Estado = estado;
            CoberturaAntiChuva = coberturaAntiChuva;
            Elenco = elenco;
        }
    }
}
