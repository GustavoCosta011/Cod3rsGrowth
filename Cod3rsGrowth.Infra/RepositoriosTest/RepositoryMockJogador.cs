﻿using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;


namespace Cod3rsGrowth.Infra.RepositoriosTest;

public class RepositoryMockJogador : IRepositoryData<Jogador> 
{

    public List<Jogador> ListaJogador;
    public Jogador? jogador;

    public RepositoryMockJogador()
    {
        ListaJogador = new List<Jogador>()
        {
             new(10, "Gabi", 27, DateTime.Parse("30-08-1996"), 1.78, 68.0),
             new(11, "PedroQuexada", 25, DateTime.Parse("17-01-1998"), 1.88, 78.0),
             new(12, "Sabino", 19, DateTime.Parse("03-03-2005"), 1.70, 73.0),
             new(13, "Halandinho", 17, DateTime.Parse("30-08-2007"), 1.75, 76.0),
             new(14, "Penaldo", 33, DateTime.Parse("30-09-1991"), 1.77, 89.0),
             new(15, "Pepssi", 30, DateTime.Parse("17-10-1994"), 1.90, 77.0),
             new(16, "HulkBundaGol", 35, DateTime.Parse("22-12-1989"), 1.68, 69.0)
             

        };

    }
    public List<Jogador>? ObterTodos()
    {
        return ListaJogador;
    }

    public Jogador ObterPorId(int id)
    {

        foreach (Jogador jogador in ListaJogador)
        {
            if (jogador.Id == id) break;
        }

        return jogador;
    }
    public Jogador Criar(Jogador jogador)
    {
        jogador.Id = 11;
        jogador.Nome = "Zé da Manga";
        jogador.Idade = 19;
        jogador.DataDeNascimento = DateTime.Parse("22-04-2005");
        jogador.Altura = 1.70;
        jogador.Peso = 68.0;
        ListaJogador.Add(jogador);
        return jogador;
    }




}

