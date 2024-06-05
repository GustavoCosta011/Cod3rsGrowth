﻿using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra;
using System.Linq;

namespace Cod3rsGrowth.Test.Repositorios
{
    public class RepositoryClube : IRepositoryBancoDeDados<Clube>
    {
        private readonly Cod3rsGrowthConnect database;

        public RepositoryClube(Cod3rsGrowthConnect Database)
        {
            database = Database;
        }

        public List<Clube> ObterTodos(string searchName)
        {
            if (searchName == null)
            {
                return database.Clubes.ToList();
            }
                return database.Clubes.Where(clube => clube.Nome.Contains(searchName)).ToList();
        }

        public Clube ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public int Criar(Clube objeto)
        {
            throw new NotImplementedException();
        }

        public void Editar(int id, Clube objeto)
        {
            throw new NotImplementedException();
        }

        public void Remover(int id)
        {
            throw new NotImplementedException();
        }
    }
}
