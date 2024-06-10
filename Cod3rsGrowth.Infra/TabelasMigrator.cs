using FluentMigrator;


namespace Cod3rsGrowth.Infra
{
    public class TabelasMigrator
    {
        [Migration(20240604100200)]
        public class TabelasMigration : Migration
        {
            public override void Up()
            {
                Create.Table("Jogador")
                    .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("Name").AsString()
                    .WithColumn("IdClube").AsInt64()
                    .WithColumn("Idade").AsInt64()
                    .WithColumn("DataDeNascimento").AsDateTime()
                    .WithColumn("Altura").AsDouble()
                    .WithColumn("Peso").AsDouble();

                Create.Table("Clube")
                    .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("Name").AsString()
                    .WithColumn("Fundacao").AsDateTime()
                    .WithColumn("Estadio").AsString()
                    .WithColumn("Estado").AsInt64()
                    .WithColumn("CoberturaAntiChuva").AsBoolean();
            }

            public override void Down()
            {
                Delete.Table("Jogador");
                Delete.Table("Clube");
            }
        }
    }
}