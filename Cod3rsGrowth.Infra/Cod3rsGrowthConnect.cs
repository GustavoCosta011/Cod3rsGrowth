using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;
using LinqToDB.Data;



namespace Cod3rsGrowth.Infra
{
    public class Cod3rsGrowthConnect : DataConnection
    {
        public Cod3rsGrowthConnect(DataOptions<Cod3rsGrowthConnect> options) : base(options.Options){ }

        public ITable<Clube> Clubes =>  this.GetTable<Clube>();
        public ITable<Jogador> Jogadores => this.GetTable<Jogador>();
    }
}
