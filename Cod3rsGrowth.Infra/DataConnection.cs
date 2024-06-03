using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.SchemaProvider;

namespace Cod3rsGrowth.Infra
{
    public class ProjetoDataConnection : DataConnection
    {
        public ProjetoDataConnection(DataOptions<ProjetoDataConnection> options) : base(options.Options)
        {

        }
    }
}
