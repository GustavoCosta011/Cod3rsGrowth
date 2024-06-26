﻿using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Modelos;
    
    namespace Cod3rsGrowth.Test.Singletons.Singleton
    {
        public sealed class ClasseSingleton
        {
            private static ClasseSingleton instance = null;

            public List<Clube> Clubes { get; set; }
            public List<Jogador> Jogadores { get; set; }
            public List<int>? ListaElenco = null;
            private ClasseSingleton()
            {
                Jogadores = new List<Jogador>()
                {
                     new(10, "Gabi", 27, DateTime.Parse("30-08-1996"), 1.78, 68.0),
                     new(11, "PedroQuexada", 25, DateTime.Parse("17-01-1998"), 1.88, 78.0),
                     new(12, "Souza", 17, DateTime.Parse("30-08-2007"), 1.75, 76.0),
                     new(13, "Halandinho", 17, DateTime.Parse("30-08-2007"), 1.75, 76.0),
                     new(14, "Penaldo", 33, DateTime.Parse("30-09-1991"), 1.77, 89.0),
                     new(15, "Pepssi", 30, DateTime.Parse("17-10-1994"), 1.90, 77.0),
                };
                Clubes = new List<Clube>()
                {
                    new(001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracanã", EstadosEnum.RJ, false, null),
                    new(002, "FC Rondonia", DateTime.Parse("22-12-1970"), "Arena RO", EstadosEnum.RO, true, null)
                };
            }

            public static ClasseSingleton Instance
            {
                get
                {
                   return instance ??= new ClasseSingleton();
                }
            }
            public void Initialize() { }
        }
    }

