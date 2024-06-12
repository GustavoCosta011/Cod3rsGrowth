using LinqToDB.Mapping;

namespace Cod3rsGrowth.Dominio.Modelos
{
    [Table("Jogador")]
    public class Jogador
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        
        [Column("Nome"), NotNull]
        public string Nome { get; set; }
            
        [Column("IdClube")]
        public int? IdClube { get; set; }

        [Column("Idade")]
        public int? Idade { get; set; }
       
        [Column("DataDeNascimento"), NotNull]
        public DateTime DataDeNascimento { get; set; }
       
        [Column("Altura")]
        public double? Altura { get; set; }
       
        [Column("Peso")]
        public double? Peso { get; set; }


        public Jogador(int id, string nome,int? idClube, int? idade, DateTime dataDeNascimento, double? altura, double? peso)
        {
            Id = id;
            Nome = nome;
            IdClube = idClube;
            Idade = idade;
            DataDeNascimento = dataDeNascimento;
            Altura = altura;
            Peso = peso;
        }
        public Jogador() { }
    }

}
