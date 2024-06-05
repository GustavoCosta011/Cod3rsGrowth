﻿using Cod3rsGrowth.Dominio.Modelos;
using LinqToDB;
using LinqToDB.Data;
using System.Configuration;


namespace Cod3rsGrowth.Infra
{
    public class Cod3rsGrowthConnect : DataConnection
    {
        public Cod3rsGrowthConnect(DataOptions<Cod3rsGrowthConnect> opcao) : base(opcao.Options) { }
        public Cod3rsGrowthConnect(string connection) : base(connection) { }

        public static Cod3rsGrowthConnect Connect(string connection)
        {
            var strConnect = ConfigurationManager.ConnectionStrings[connection].ConnectionString;
            return new Cod3rsGrowthConnect(strConnect);
        }

        public ITable<Clube>? Clubes = null;
        public ITable<Jogador>? Jogadores = null;
    } 
}