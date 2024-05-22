﻿using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;


namespace Cod3rsGrowth.Infra.RepositoriosTest
{
    public class RepositoryMockClube : IRepositoryData<Clube> 
    {
        public List<Clube> ListaDeClubes;
        public Clube? clube;
        public List<Jogador>? ListaJogadores;
        public RepositoryMockClube()
        {
            ListaDeClubes = new List<Clube>()
            {
                new (001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracanã",EstadosEnum.RJ, false,ListaJogadores)
            };
            
        }

        public List<Clube> ObterTodos()
        {
            return ListaDeClubes;
        }

        public Clube ObterPorId(int id)
        {
           return ListaDeClubes.Find(clube => clube.Id == id);
            




        }
            
        public Clube Criar(Clube clube) 
        {  
            return clube; 
        }
        //{
        //    clube.Id = 5;
        //    clube.Nome = "PimbaFC";
        //    clube.Fundacao = DateTime.Parse("24-11-2008");
        //    clube.Estadio = "Arena Pimbador";
        //    clube.Estado = EstadosEnum.GO;
        //    clube.CoberturaAntiChuva = false;
        //    clube.Elenco = new List<Jogador>()
        //    {
        //        new(10, "Emibape", 22, DateTime.Parse("23-08-2002"), 1.80, 80.0)
        //    };
        //    ListaDeClubes.Add(clube);


        //    return clube;
        //}


    }
}
