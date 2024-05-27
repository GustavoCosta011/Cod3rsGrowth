namespace Cod3rsGrowth.Dominio.Modelos
{

    public class Jogador
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int? Idade { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public double? Altura { get; set; }
        public double? Peso { get; set; }

        public Jogador(int? id, string nome, int idade, DateTime dataDeNascimento, double? altura, double? peso)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            DataDeNascimento = dataDeNascimento;
            Altura = altura;
            Peso = peso;
        }
    }

}
