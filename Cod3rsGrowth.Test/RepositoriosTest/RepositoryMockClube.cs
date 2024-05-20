using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Interfaces;

namespace Cod3rsGrowth.Test.RepositoriosTest
{
    public class RepositoryMockClube : IRepositoryClube<Clube>
    {
        public List<Clube> ListaDeClubes;
        public Clube clube;
        public List<Jogador>? ListaJogadores;
        public RepositoryMockClube()
        {
            ListaDeClubes = new List<Clube>()
            {
                new (001, "Flamengo", DateTime.Parse("15-11-1895"), "Maracanã",EstadosEnum.RJ, false, ListaJogadores)
            };
            
        }

        public List<Clube> ObterTodos()
        {
            return ListaDeClubes;
        }

        public Clube ObterPorId(int id)
        {

            foreach (Clube clube in ListaDeClubes)
            {
                if (clube.Id == id)
                {
                    continue;
                }

            }

            return clube;
        }
        Clube IRepositoryClube<Clube>.Criar(int id, string nome, DateTime fundacao, string? estadio, EstadosEnum estado, bool coberturaAntiChuva, List<Jogador>? elenco)
        {
            clube.Id = id;
            clube.Nome = nome;
            clube.Fundacao = fundacao;
            clube.Estadio = estadio;
            clube.Estado = estado;
            clube.CoberturaAntiChuva = coberturaAntiChuva;
            clube.Elenco = elenco;

            ListaDeClubes.Add(clube);


            return clube;
        }

        

       
    }
}
