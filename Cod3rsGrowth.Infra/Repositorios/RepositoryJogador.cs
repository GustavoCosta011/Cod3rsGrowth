﻿using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Test.Repositorios;

public class RepositoryJogador : IRepositoryBancoDeDados<Jogador>
{
    public List<Jogador> ObterTodos(string searchName)
    {
        throw new NotImplementedException();
    }

    public Jogador ObterPorId(int id)
    {
        throw new NotImplementedException();
    }

    public int Criar(Jogador objeto)
    {
        throw new NotImplementedException();
    }

    public void Editar(int id, Jogador objeto)
    {
        throw new NotImplementedException();
    }

    public void Remover(int id)
    {
        throw new NotImplementedException();
    }
}


