namespace Cod3rsGrowth.Dominio
{

    public class Jogadores
    {
        public int Id { get; }
        public string? Nome { get; }
        public int Idade { get; }
        public DateTime DataDeNascimento { get; set; } 
        public float Altura { get; set; }
        public float Peso { get; set; }

        public Jogadores()
        {

        }

    }




    public class Clubes
    {
        public int Id { get; }
        public string? Nome { get; }
        public DateTime Fundacao { get; set; }
        public string Estadio { get; set; }
        public EstadosEnum Estado { get; set; }
        public bool CoberturaAntiChuva { get; set; }
        public List<Jogadores>? Elenco {  get; set; }


    }
}
