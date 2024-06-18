using System.Numerics;
using Cod3rsGrowth.Dominio.Enums;
using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Modelos
{
   
    [Table("Clube")]
    public class Clube
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }

        [Column("Nome"), NotNull]
        public string Nome { get; set; }

        [Column("Fundacao"), NotNull]
        public DateTime Fundacao { get; set; }

        [Column("Estadio")]
        public string? Estadio { get; set; }

        [Column("Estado"),NotNull]
        public EstadosEnum Estado { get; set; }

        [Column("CoberturaTeto"), NotNull]
        public bool CoberturaAntiChuva { get; set; }

        public List<int>? Elenco { get; set; }

        public Clube(int id, string nome, DateTime fundacao, string? estadio, EstadosEnum estado, bool coberturaAntiChuva, List<int>? elenco)
        {
            Id = id;
            Nome = nome;
            Fundacao = fundacao;
            Estadio = estadio;
            Estado = estado;
            CoberturaAntiChuva = coberturaAntiChuva;
            Elenco = elenco;
        }
        public Clube(){ }
    }
}
