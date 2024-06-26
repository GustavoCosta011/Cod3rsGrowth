using System.Numerics;
using FluentMigrator;
using LinqToDB.Mapping;


namespace Cod3rsGrowth.Infra
{
    public class TabelasMigrator
    {
        [Migration(20242606124300)]
        public class TabelasMigration : Migration
        {
            public override void Up()
            {
                Create.Table("Jogador")
                    .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("Nome").AsString()
                    .WithColumn("IdClube").AsInt64().Nullable()
                    .WithColumn("Clube").AsString().Nullable()
                    .WithColumn("Idade").AsInt64()
                    .WithColumn("DataDeNascimento").AsDateTime()
                    .WithColumn("Altura").AsDouble()
                    .WithColumn("Peso").AsDouble();

                Create.Table("Clube")
                    .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                    .WithColumn("Nome").AsString().Unique() 
                    .WithColumn("Fundacao").AsDateTime()
                    .WithColumn("Estadio").AsString()
                    .WithColumn("Estado").AsInt64()
                    .WithColumn("CoberturaTeto").AsBoolean();

                Create.ForeignKey()
                    .FromTable("Jogador").ForeignColumn("IdClube")
                    .ToTable("Clube").PrimaryColumn("Id")
                    .OnDeleteOrUpdate(System.Data.Rule.SetNull);
            }

            public override void Down()
            {
                Delete.Table("Jogador");
                Delete.Table("Clube");
            }
        }
    }
}