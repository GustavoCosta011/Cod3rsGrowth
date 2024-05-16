namespace Cod3rsGrowth.Dominio
{

    public class Jogador
    {
        public int Id { get; }
        public string Nome { get; }
        public int Idade { get; }
        public DateTime DataDeNascimento { get; } 
        public double Altura { get; set; }
        public double Peso { get; set; }

        public Jogador (int id, string nome, int idade, DateTime dataDeNascimento, double altura, double peso)
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
