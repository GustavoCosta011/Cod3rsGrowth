using FluentMigrator;


namespace Cod3rsGrowth.Infra
{
    public class FluentMigrator
    {
 

        [Migration(20240604100200)]
        public class TabelasMigration : Migration
        {
            public override void Up()
            {
                Create.Table("Jogador")
                    .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("Name").AsString()
                    .WithColumn("Idade").AsInt64()
                    .WithColumn("DataDeNascimento").AsDateTime()
                    .WithColumn("Altura").AsDouble()
                    .WithColumn("Peso").AsDouble();

                Create.Table("Clube")
                    .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("Name").AsString()
                    .WithColumn("Fundacao").AsDateTime()
                    .WithColumn("Estadio").AsString()
                    .WithColumn("Estado").AsString()
                    .WithColumn("CoberturaAntiChuva").AsBoolean()
                    .WithColumn("Elenco").AsInt32();
            
            }

            public override void Down()
            {
                Delete.Table("Jogador");
                Delete.Table("Clube");
            }
        }
    }
}
}
