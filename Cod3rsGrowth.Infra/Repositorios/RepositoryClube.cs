﻿using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;



namespace Cod3rsGrowth.Test.Repositorios
{
    public class RepositoryClube : IRepositoryData<Clube> 
    {
        public List<Clube>? ListaDeClubes;
        public Clube? clube;

        public List<Clube> ObterTodos()
        {
            return ListaDeClubes;
        }

        public Clube ObterPorId(int id)
        {
           return ListaDeClubes.Find(clube => clube.Id == id) ?? throw new Exception("Clube inexistente!");
        }
            
        public int Criar(Clube clube)
        {
            int IncrementoCriar = 1;
            clube.Id = ListaDeClubes.Any() ? ListaDeClubes.Max(clube => clube.Id) + IncrementoCriar : IncrementoCriar;

            ListaDeClubes.Add(clube);

            return clube.Id;

        }

        public void Editar(int idDoEdit, Clube clube)
        {
            
            var ClubeAEditar = ObterPorId(idDoEdit);

            ClubeAEditar.Nome = clube.Nome;
            
            ClubeAEditar.Fundacao = clube.Fundacao;

            ClubeAEditar.Estadio = clube.Estadio;

            ClubeAEditar.Estado = clube.Estado;

            ClubeAEditar.CoberturaAntiChuva = clube.CoberturaAntiChuva;

            ClubeAEditar.Elenco = clube.Elenco;

        }

        public void Remover(int id)

        {
            var clubeARemover = ObterPorId(id);
            ListaDeClubes.Remove(clubeARemover);
        }
    }
}
