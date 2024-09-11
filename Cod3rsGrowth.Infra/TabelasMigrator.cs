using FluentMigrator;

namespace Cod3rsGrowth.Infra
{
    [Migration(20241608125500)]
    public class TabelasMigrator : Migration
    {
        public override void Up()
        {
            Create.Table("Clube")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().Unique()
                .WithColumn("Fundacao").AsDateTime()
                .WithColumn("Estadio").AsString()
                .WithColumn("Estado").AsInt64()
                .WithColumn("CoberturaTeto").AsBoolean();

            Create.Table("Jogador")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Nome").AsString()
                .WithColumn("IdClube").AsInt64().Nullable()
                .WithColumn("Clube").AsString().Nullable()
                .WithColumn("Idade").AsInt64()
                .WithColumn("DataDeNascimento").AsDateTime()
                .WithColumn("Altura").AsDouble()
                .WithColumn("Peso").AsDouble();

            Create.ForeignKey()
                .FromTable("Jogador").ForeignColumn("IdClube")
                .ToTable("Clube").PrimaryColumn("Id")
                .OnDeleteOrUpdate(System.Data.Rule.SetNull);

            Execute.Sql(@"
                INSERT INTO Clube (Nome, Fundacao, Estadio, Estado, CoberturaTeto) VALUES
                ('Atlético Mineiro', '25-03-1908', 'Arena MRV', 11, 1),
                ('Atlético Paranaense', '26-03-1924', 'Arena da Baixada', 14, 1),
                ('Bahia', '01-01-1931', 'Arena Fonte Nova', 4, 1),
                ('Botafogo', '12-08-1894', 'Nilton Santos', 17, 1),
                ('Corinthians', '01-09-1910', 'Neo Química Arena', 23, 1),
                ('Coritiba', '12-10-1909', 'Couto Pereira', 14, 0),
                ('Cruzeiro', '02-01-1921', 'Mineirão', 11, 1),
                ('Cuiabá', '10-12-2001', 'Arena Pantanal', 9, 1),
                ('Flamengo', '17-11-1895', 'Maracanã', 17, 1),
                ('Fluminense', '21-07-1902', 'Maracanã', 17, 1),
                ('Fortaleza', '18-10-1918', 'Castelão', 5, 1),
                ('Goiás', '06-04-1943', 'Serrinha', 7, 0),
                ('Grêmio', '15-09-1903', 'Arena do Grêmio', 19, 1),
                ('Internacional', '04-04-1909', 'Beira-Rio', 19, 1),
                ('Palmeiras', '26-08-1914', 'Allianz Parque', 23, 1),
                ('Red Bull Bragantino', '08-01-1928', 'Nabi Abi Chedid', 23, 0),
                ('Santos', '14-04-1912', 'Vila Belmiro', 23, 0),
                ('São Paulo', '25-01-1930', 'Morumbi', 23, 0),
                ('Vasco da Gama', '21-08-1898', 'São Januário', 17, 0),
                ('Grêmio Novorizontino', '13-03-1973', 'Estádio Jorge Ismael de Biasi', 23, 0);"

            );

            Execute.Sql(@"
                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Everson', 1, 'Atlético Mineiro', 32, '22-07-1988', 1.92, 82.0),
                ('Mariano', 1, 'Atlético Mineiro', 34, '23-06-1986', 1.79, 73.0),
                ('Junior Alonso', 1, 'Atlético Mineiro', 28, '09-02-1993', 1.84, 79.0),
                ('Nathan Silva', 1, 'Atlético Mineiro', 24, '06-05-1997', 1.84, 76.0),
                ('Arana', 1, 'Atlético Mineiro', 24, '14-04-1997', 1.76, 70.0),
                ('Jair', 1, 'Atlético Mineiro', 27, '03-04-1994', 1.74, 72.0),
                ('Allan', 1, 'Atlético Mineiro', 24, '03-01-1997', 1.74, 70.0),
                ('Hulk', 1, 'Atlético Mineiro', 34, '25-07-1986', 1.80, 85.0),
                ('Nacho Fernández', 1, 'Atlético Mineiro', 31, '12-01-1990', 1.81, 75.0),
                ('Keno', 1, 'Atlético Mineiro', 31, '10-09-1989', 1.78, 72.0),
                ('Vargas', 1, 'Atlético Mineiro', 31, '20-11-1989', 1.75, 70.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Santos', 2, 'Atlético Paranaense', 31, '17-03-1990', 1.88, 82.0),
                ('Kelvin', 2, 'Atlético Paranaense', 27, '01-06-1994', 1.78, 71.0),
                ('Thiago Heleno', 2, 'Atlético Paranaense', 33, '17-09-1988', 1.85, 84.0),
                ('Pedro Henrique', 2, 'Atlético Paranaense', 26, '02-10-1995', 1.85, 78.0),
                ('Abner Vinícius', 2, 'Atlético Paranaense', 21, '27-05-2000', 1.81, 75.0),
                ('Christian', 2, 'Atlético Paranaense', 20, '20-04-2001', 1.76, 71.0),
                ('Erick', 2, 'Atlético Paranaense', 22, '11-03-1999', 1.75, 70.0),
                ('Nikão', 2, 'Atlético Paranaense', 28, '29-07-1992', 1.75, 72.0),
                ('Léo Cittadini', 2, 'Atlético Paranaense', 27, '27-02-1994', 1.79, 73.0),
                ('Renato Kayzer', 2, 'Atlético Paranaense', 25, '17-02-1996', 1.83, 77.0),
                ('Carlos Eduardo', 2, 'Atlético Paranaense', 24, '17-10-1996', 1.81, 75.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Matheus Teixeira', 3, 'Bahia', 22, '01-03-1999', 1.90, 83.0),
                ('Nino Paraíba', 3, 'Bahia', 34, '10-01-1986', 1.75, 70.0),
                ('Luiz Otávio', 3, 'Bahia', 29, '14-10-1991', 1.90, 82.0),
                ('Germán Conti', 3, 'Bahia', 27, '03-06-1994', 1.93, 80.0),
                ('Matheus Bahia', 3, 'Bahia', 21, '26-02-2000', 1.76, 70.0),
                ('Patrick de Lucca', 3, 'Bahia', 21, '01-05-2000', 1.80, 74.0),
                ('Danielzinho', 3, 'Bahia', 25, '30-07-1995', 1.75, 72.0),
                ('Thaciano', 3, 'Bahia', 26, '12-05-1995', 1.80, 75.0),
                ('Rossi', 3, 'Bahia', 28, '22-04-1993', 1.78, 72.0),
                ('Gilberto', 3, 'Bahia', 32, '05-06-1989', 1.78, 75.0),
                ('Rodriguinho', 3, 'Bahia', 33, '27-03-1988', 1.77, 73.0);
                
                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Douglas Borges', 4, 'Botafogo', 31, '06-03-1990', 1.90, 84.0),
                ('Jonathan', 4, 'Botafogo', 28, '18-02-1993', 1.73, 72.0),
                ('Kanu', 4, 'Botafogo', 24, '08-03-1997', 1.86, 80.0),
                ('Gilvan', 4, 'Botafogo', 31, '07-05-1990', 1.85, 82.0),
                ('Paulo Victor', 4, 'Botafogo', 20, '21-01-2001', 1.80, 75.0),
                ('Matheus Frizzo', 4, 'Botafogo', 23, '07-04-1998', 1.83, 76.0),
                ('Rickson', 4, 'Botafogo', 23, '18-02-1998', 1.78, 72.0),
                ('Pedro Castro', 4, 'Botafogo', 28, '05-02-1993', 1.80, 75.0),
                ('Marco Antônio', 4, 'Botafogo', 24, '02-01-1997', 1.70, 70.0),
                ('Rafael Navarro', 4, 'Botafogo', 21, '14-04-2000', 1.83, 77.0),
                ('Ronald', 4, 'Botafogo', 24, '05-04-1997', 1.75, 72.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Cássio', 5, 'Corinthians', 33, '06-06-1987', 1.95, 90.0),
                ('Fagner', 5, 'Corinthians', 32, '11-06-1989', 1.68, 67.0),
                ('Gil', 5, 'Corinthians', 34, '12-06-1987', 1.92, 87.0),
                ('João Victor', 5, 'Corinthians', 22, '17-07-1998', 1.87, 80.0),
                ('Fábio Santos', 5, 'Corinthians', 35, '16-09-1985', 1.76, 72.0),
                ('Gabriel', 5, 'Corinthians', 28, '10-06-1992', 1.75, 72.0),
                ('Cantillo', 5, 'Corinthians', 27, '15-01-1993', 1.80, 73.0),
                ('Roni', 5, 'Corinthians', 21, '07-04-2000', 1.76, 70.0),
                ('Mateus Vital', 5, 'Corinthians', 23, '12-02-1998', 1.75, 69.0),
                ('Luan', 5, 'Corinthians', 28, '27-03-1993', 1.80, 75.0),
                ('Jô', 5, 'Corinthians', 34, '20-03-1987', 1.90, 85.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Wilson', 6, 'Coritiba', 36, '31-01-1984', 1.88, 83.0),
                ('Natanael', 6, 'Coritiba', 19, '25-12-2001', 1.76, 71.0),
                ('Henrique', 6, 'Coritiba', 34, '14-10-1986', 1.87, 80.0),
                ('Luciano Castan', 6, 'Coritiba', 31, '13-09-1989', 1.87, 82.0),
                ('Guilherme Biro', 6, 'Coritiba', 26, '03-04-1995', 1.74, 73.0),
                ('Matheus Salles', 6, 'Coritiba', 25, '03-06-1995', 1.76, 72.0),
                ('Willian Farias', 6, 'Coritiba', 31, '06-06-1989', 1.75, 73.0),
                ('Robinho', 6, 'Coritiba', 33, '10-08-1987', 1.75, 72.0),
                ('Rafinha', 6, 'Coritiba', 38, '04-09-1982', 1.70, 68.0),
                ('Léo Gamalho', 6, 'Coritiba', 35, '30-01-1985', 1.88, 85.0),
                ('Waguininho', 6, 'Coritiba', 31, '30-10-1989', 1.78, 72.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Fábio', 7, 'Cruzeiro', 40, '30-09-1980', 1.88, 84.0),
                ('Raúl Cáceres', 7, 'Cruzeiro', 29, '18-09-1991', 1.78, 73.0),
                ('Ramon', 7, 'Cruzeiro', 25, '20-05-1995', 1.86, 80.0),
                ('Léo', 7, 'Cruzeiro', 33, '30-01-1987', 1.88, 82.0),
                ('Matheus Pereira', 7, 'Cruzeiro', 19, '10-03-2001', 1.76, 71.0),
                ('Henrique', 7, 'Cruzeiro', 35, '16-05-1985', 1.75, 72.0),
                ('Adriano', 7, 'Cruzeiro', 21, '02-09-1999', 1.75, 70.0),
                ('Claudinho', 7, 'Cruzeiro', 20, '24-03-2001', 1.77, 72.0),
                ('Rafael Sobis', 7, 'Cruzeiro', 36, '17-06-1985', 1.79, 74.0),
                ('Bruno José', 7, 'Cruzeiro', 23, '15-02-1998', 1.76, 71.0),
                ('Marcinho', 7, 'Cruzeiro', 26, '08-03-1995', 1.76, 72.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Walter', 8, 'Cuiabá', 33, '18-12-1987', 1.88, 85.0),
                ('João Lucas', 8, 'Cuiabá', 22, '22-01-1999', 1.76, 71.0),
                ('Anderson Conceição', 8, 'Cuiabá', 31, '24-10-1989', 1.85, 82.0),
                ('Paulão', 8, 'Cuiabá', 35, '06-09-1986', 1.87, 84.0),
                ('Uendel', 8, 'Cuiabá', 32, '08-10-1988', 1.76, 72.0),
                ('Auremir', 8, 'Cuiabá', 29, '10-03-1992', 1.75, 71.0),
                ('Camilo', 8, 'Cuiabá', 35, '09-03-1986', 1.74, 70.0),
                ('Pepe', 8, 'Cuiabá', 23, '21-04-1998', 1.78, 72.0),
                ('Elton', 8, 'Cuiabá', 35, '01-08-1985', 1.85, 83.0),
                ('Jenison', 8, 'Cuiabá', 29, '06-07-1991', 1.80, 78.0),
                ('Jonathan Cafú', 8, 'Cuiabá', 29, '10-07-1991', 1.77, 72.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Diego Alves', 9, 'Flamengo', 36, '24-06-1985', 1.88, 84.0),
                ('Isla', 9, 'Flamengo', 33, '12-06-1988', 1.76, 71.0),
                ('Rodrigo Caio', 9, 'Flamengo', 28, '17-08-1993', 1.82, 77.0),
                ('Gustavo Henrique', 9, 'Flamengo', 28, '24-03-1993', 1.96, 85.0),
                ('Filipe Luís', 9, 'Flamengo', 36, '09-08-1985', 1.82, 73.0),
                ('Willian Arão', 9, 'Flamengo', 29, '12-03-1992', 1.81, 73.0),
                ('Gerson', 9, 'Flamengo', 24, '20-05-1997', 1.85, 79.0),
                ('Everton Ribeiro', 9, 'Flamengo', 32, '10-04-1989', 1.74, 68.0),
                ('Arrascaeta', 9, 'Flamengo', 27, '01-06-1994', 1.72, 67.0),
                ('Bruno Henrique', 9, 'Flamengo', 30, '30-12-1990', 1.84, 76.0),
                ('Gabigol', 9, 'Flamengo', 25, '30-08-1996', 1.76, 72.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Marcos Felipe', 10, 'Fluminense', 25, '13-04-1996', 1.89, 83.0),
                ('Calegari', 10, 'Fluminense', 19, '23-02-2002', 1.78, 71.0),
                ('Nino', 10, 'Fluminense', 24, '10-04-1997', 1.88, 82.0),
                ('Lucas Claro', 10, 'Fluminense', 29, '02-10-1991', 1.85, 81.0),
                ('Egídio', 10, 'Fluminense', 34, '16-06-1986', 1.82, 73.0),
                ('André', 10, 'Fluminense', 20, '16-07-2001', 1.76, 71.0),
                ('Yago Felipe', 10, 'Fluminense', 26, '13-02-1994', 1.75, 72.0),
                ('Nenê', 10, 'Fluminense', 39, '19-07-1981', 1.80, 73.0),
                ('Caio Paulista', 10, 'Fluminense', 23, '11-05-1998', 1.82, 75.0),
                ('Fred', 10, 'Fluminense', 37, '03-10-1983', 1.85, 81.0),
                ('Lucca', 10, 'Fluminense', 31, '14-02-1990', 1.80, 75.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Felipe Alves', 11, 'Fortaleza', 32, '15-05-1988', 1.88, 82.0),
                ('Tinga', 11, 'Fortaleza', 27, '01-09-1993', 1.75, 72.0),
                ('Paulão', 11, 'Fortaleza', 34, '06-09-1986', 1.88, 85.0),
                ('Jackson', 11, 'Fortaleza', 30, '01-05-1990', 1.85, 80.0),
                ('Bruno Melo', 11, 'Fortaleza', 28, '26-10-1992', 1.80, 78.0),
                ('Juninho', 11, 'Fortaleza', 34, '21-01-1987', 1.78, 72.0),
                ('Felipe', 11, 'Fortaleza', 26, '25-07-1994', 1.75, 70.0),
                ('David', 11, 'Fortaleza', 25, '17-10-1995', 1.77, 73.0),
                ('Romarinho', 11, 'Fortaleza', 26, '01-12-1994', 1.70, 68.0),
                ('Wellington Paulista', 11, 'Fortaleza', 37, '22-04-1983', 1.83, 80.0),
                ('Osvaldo', 11, 'Fortaleza', 33, '11-04-1987', 1.70, 66.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Tadeu', 12, 'Goiás', 28, '24-11-1992', 1.88, 84.0),
                ('Edilson', 12, 'Goiás', 34, '04-07-1986', 1.75, 72.0),
                ('David Duarte', 12, 'Goiás', 25, '24-01-1996', 1.90, 83.0),
                ('Fábio Sanches', 12, 'Goiás', 29, '01-08-1991', 1.84, 81.0),
                ('Jefferson', 12, 'Goiás', 23, '15-01-1997', 1.77, 70.0),
                ('Breno', 12, 'Goiás', 25, '01-02-1996', 1.75, 72.0),
                ('Ariel Cabral', 12, 'Goiás', 33, '11-09-1987', 1.87, 81.0),
                ('Daniel Bessa', 12, 'Goiás', 28, '14-01-1993', 1.75, 72.0),
                ('Rafael Moura', 12, 'Goiás', 38, '23-05-1983', 1.89, 85.0),
                ('Vinícius Lopes', 12, 'Goiás', 22, '07-04-1999', 1.80, 75.0),
                ('Shaylon', 12, 'Goiás', 24, '27-04-1997', 1.78, 72.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Brenno', 13, 'Grêmio', 22, '13-04-1999', 1.90, 83.0),
                ('Rafinha', 13, 'Grêmio', 35, '07-09-1985', 1.72, 72.0),
                ('Geromel', 13, 'Grêmio', 35, '21-09-1985', 1.90, 83.0),
                ('Kannemann', 13, 'Grêmio', 29, '14-03-1991', 1.83, 81.0),
                ('Diogo Barbosa', 13, 'Grêmio', 28, '17-08-1992', 1.79, 72.0),
                ('Thiago Santos', 13, 'Grêmio', 31, '05-09-1989', 1.80, 75.0),
                ('Matheus Henrique', 13, 'Grêmio', 23, '19-12-1997', 1.75, 72.0),
                ('Jean Pyerre', 13, 'Grêmio', 23, '07-05-1998', 1.81, 71.0),
                ('Ferreira', 13, 'Grêmio', 23, '14-12-1997', 1.75, 70.0),
                ('Diego Souza', 13, 'Grêmio', 35, '17-06-1985', 1.86, 84.0),
                ('Alisson', 13, 'Grêmio', 28, '25-06-1993', 1.75, 72.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Marcelo Lomba', 14, 'Internacional', 34, '18-12-1986', 1.88, 83.0),
                ('Saravia', 14, 'Internacional', 28, '02-06-1992', 1.78, 72.0),
                ('Víctor Cuesta', 14, 'Internacional', 32, '19-11-1988', 1.87, 82.0),
                ('Lucas Ribeiro', 14, 'Internacional', 22, '19-01-1999', 1.88, 83.0),
                ('Moisés', 14, 'Internacional', 26, '11-03-1995', 1.80, 75.0),
                ('Rodrigo Dourado', 14, 'Internacional', 26, '17-06-1994', 1.86, 80.0),
                ('Edenílson', 14, 'Internacional', 31, '18-12-1989', 1.75, 73.0),
                ('Patrick', 14, 'Internacional', 28, '29-07-1992', 1.80, 80.0),
                ('Taison', 14, 'Internacional', 33, '17-01-1988', 1.72, 70.0),
                ('Yuri Alberto', 14, 'Internacional', 20, '18-03-2001', 1.83, 78.0),
                ('Thiago Galhardo', 14, 'Internacional', 31, '20-07-1989', 1.83, 78.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Weverton', 15, 'Palmeiras', 33, '13-12-1987', 1.89, 84.0),
                ('Marcos Rocha', 15, 'Palmeiras', 32, '11-12-1988', 1.77, 70.0),
                ('Luan', 15, 'Palmeiras', 28, '10-05-1993', 1.88, 83.0),
                ('Gustavo Gómez', 15, 'Palmeiras', 27, '06-05-1993', 1.85, 84.0),
                ('Matías Viña', 15, 'Palmeiras', 23, '09-11-1997', 1.80, 75.0),
                ('Felipe Melo', 15, 'Palmeiras', 37, '26-06-1983', 1.83, 82.0),
                ('Danilo', 15, 'Palmeiras', 19, '29-04-2002', 1.77, 72.0),
                ('Raphael Veiga', 15, 'Palmeiras', 26, '19-06-1995', 1.78, 72.0),
                ('Gustavo Scarpa', 15, 'Palmeiras', 27, '05-01-1994', 1.76, 72.0),
                ('Rony', 15, 'Palmeiras', 26, '11-05-1995', 1.72, 68.0),
                ('Luiz Adriano', 15, 'Palmeiras', 34, '12-04-1987', 1.83, 77.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Cleiton', 16, 'Red Bull Bragantino', 24, '19-08-1997', 1.90, 83.0),
                ('Aderlan', 16, 'Red Bull Bragantino', 31, '07-08-1990', 1.75, 72.0),
                ('Léo Ortiz', 16, 'Red Bull Bragantino', 25, '03-01-1996', 1.85, 80.0),
                ('Natan', 16, 'Red Bull Bragantino', 20, '06-03-2001', 1.88, 82.0),
                ('Edimar', 16, 'Red Bull Bragantino', 35, '21-05-1986', 1.78, 73.0),
                ('Eric Ramires', 16, 'Red Bull Bragantino', 21, '10-08-2000', 1.75, 70.0),
                ('Raul', 16, 'Red Bull Bragantino', 25, '06-09-1996', 1.77, 72.0),
                ('Artur', 16, 'Red Bull Bragantino', 23, '15-02-1998', 1.72, 68.0),
                ('Ytalo', 16, 'Red Bull Bragantino', 33, '12-01-1988', 1.79, 74.0),
                ('Helinho', 16, 'Red Bull Bragantino', 21, '25-04-2000', 1.73, 69.0),
                ('Jan Hurtado', 16, 'Red Bull Bragantino', 21, '05-03-2000', 1.82, 80.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('João Paulo', 17, 'Santos', 26, '19-03-1995', 1.88, 82.0),
                ('Madson', 17, 'Santos', 29, '13-01-1992', 1.75, 70.0),
                ('Kaiky', 17, 'Santos', 17, '12-01-2004', 1.86, 78.0),
                ('Luan Peres', 17, 'Santos', 27, '19-07-1994', 1.90, 83.0),
                ('Felipe Jonatan', 17, 'Santos', 23, '15-02-1998', 1.76, 72.0),
                ('Camacho', 17, 'Santos', 31, '16-03-1990', 1.80, 75.0),
                ('Jean Mota', 17, 'Santos', 27, '15-10-1993', 1.77, 71.0),
                ('Gabriel Pirani', 17, 'Santos', 19, '12-04-2002', 1.75, 70.0),
                ('Marinho', 17, 'Santos', 31, '29-05-1990', 1.69, 71.0),
                ('Marcos Leonardo', 17, 'Santos', 18, '02-05-2003', 1.74, 70.0),
                ('Lucas Braga', 17, 'Santos', 24, '05-11-1996', 1.78, 72.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Tiago Volpi', 18, 'São Paulo', 30, '19-12-1990', 1.89, 83.0),
                ('Igor Vinicius', 18, 'São Paulo', 24, '01-04-1997', 1.75, 71.0),
                ('Arboleda', 18, 'São Paulo', 29, '22-10-1991', 1.87, 83.0),
                ('Bruno Alves', 18, 'São Paulo', 30, '16-04-1991', 1.85, 82.0),
                ('Reinaldo', 18, 'São Paulo', 31, '28-09-1989', 1.78, 76.0),
                ('Luan', 18, 'São Paulo', 22, '14-05-1999', 1.75, 73.0),
                ('Liziero', 18, 'São Paulo', 23, '07-02-1998', 1.75, 71.0),
                ('Igor Gomes', 18, 'São Paulo', 22, '17-03-1999', 1.83, 74.0),
                ('Benítez', 18, 'São Paulo', 27, '17-06-1994', 1.72, 70.0),
                ('Pablo', 18, 'São Paulo', 29, '23-06-1992', 1.85, 81.0),
                ('Luciano', 18, 'São Paulo', 28, '18-05-1993', 1.81, 76.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Lucão', 19, 'Vasco da Gama', 30, '23-06-1991', 1.93, 88.0),
                ('Zeca', 19, 'Vasco da Gama', 27, '16-05-1994', 1.72, 70.0),
                ('Leandro Castán', 19, 'Vasco da Gama', 35, '05-11-1986', 1.86, 83.0),
                ('Ernando', 19, 'Vasco da Gama', 33, '17-04-1988', 1.85, 81.0),
                ('MT', 19, 'Vasco da Gama', 20, '20-09-2001', 1.80, 73.0),
                ('Andrey', 19, 'Vasco da Gama', 23, '15-02-1998', 1.76, 72.0),
                ('Marquinhos Gabriel', 19, 'Vasco da Gama', 31, '21-07-1990', 1.75, 71.0),
                ('Morato', 19, 'Vasco da Gama', 29, '30-06-1992', 1.77, 72.0),
                ('Cano', 19, 'Vasco da Gama', 33, '02-01-1988', 1.76, 72.0),
                ('Léo Jabá', 19, 'Vasco da Gama', 23, '02-08-1998', 1.78, 73.0),
                ('Gabriel Pec', 19, 'Vasco da Gama', 20, '11-02-2001', 1.75, 70.0);

                INSERT INTO Jogador (Nome, IdClube, Clube, Idade, DataDeNascimento, Altura, Peso) VALUES
                ('Giovanni', 20, 'Grêmio Novorizontino', 26, '24-01-1995', 1.88, 84.0),
                ('Felipe Rodrigues', 20, 'Grêmio Novorizontino', 27, '24-03-1994', 1.76, 72.0),
                ('Bruno Aguiar', 20, 'Grêmio Novorizontino', 35, '26-02-1986', 1.87, 82.0),
                ('Edson Silva', 20, 'Grêmio Novorizontino', 35, '09-05-1986', 1.88, 84.0),
                ('Paulinho', 20, 'Grêmio Novorizontino', 27, '20-07-1994', 1.75, 71.0),
                ('Adilson Goiano', 20, 'Grêmio Novorizontino', 33, '21-08-1987', 1.78, 74.0),
                ('Danielzinho', 20, 'Grêmio Novorizontino', 29, '20-07-1992', 1.72, 68.0),
                ('Cléo Silva', 20, 'Grêmio Novorizontino', 32, '21-05-1989', 1.75, 70.0),
                ('Jenison', 20, 'Grêmio Novorizontino', 30, '30-06-1991', 1.83, 78.0);"
            );
        }

        public override void Down()
        {
            // Dropping tables
            Delete.Table("Jogador");
            Delete.Table("Clube");
        }
    }

    [Migration(0)]
    public class ResetarBancoDeDados : Migration
    {
        public override void Up() { }

        public override void Down()
        {
            Delete.Table("Clube");
            Delete.Table("Jogador");
            Delete.Table("VersionInfo");
        }
    }
}
