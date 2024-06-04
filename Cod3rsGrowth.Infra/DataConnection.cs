using LinqToDB.Data;
using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;
using static LinqToDB.Reflection.Methods.LinqToDB;


namespace Cod3rsGrowth.Infra
{
    public class Cod3rsGrowthDb : DataConnection
    {
        public Cod3rsGrowthDb() : base("Cod3rsGrowth") { }

    }
}
