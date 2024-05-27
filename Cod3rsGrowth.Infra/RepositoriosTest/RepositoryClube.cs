using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons.Testes.Singleton;
using System.Reflection.Metadata.Ecma335;


namespace Cod3rsGrowth.Infra.RepositoriosTest
{
    public class RepositoryClube : IRepositoryData<Clube> 
    {
        public List<Clube>? ListaDeClubes = ClasseSingleton.Instance.Clubes;
        public Clube? clube;
        
      

        public List<Clube> ObterTodos()
        {
            return ListaDeClubes;
        }

        public Clube ObterPorId(int? id)
        {
           return ListaDeClubes.Find(clube => clube.Id == id) ??throw new Exception("Clube inexistente!");
        }
            
        public int? Criar(Clube clube)
        {
            int IncrementoCriar = 1;
            clube.Id = ListaDeClubes.Any() ? ListaDeClubes.Max(clube => clube.Id) + IncrementoCriar : IncrementoCriar;

            ListaDeClubes.Add(clube);

            return clube.Id;

        }

        public void Editar(int? idDoEdit, Clube clube)
        {
            
            var ClubeAEditar = ObterPorId(idDoEdit);

            ClubeAEditar.Nome = clube.Nome;
            
            ClubeAEditar.Fundacao = clube.Fundacao;

            ClubeAEditar.Estadio = clube.Estadio;

            ClubeAEditar.Estado = clube.Estado;

            ClubeAEditar.CoberturaAntiChuva = false;

            ClubeAEditar.CoberturaAntiChuva = true;

            ClubeAEditar.Elenco = clube.Elenco;

        }

        public int? Remover(int? id)
        {

            var clubeRemover = ObterPorId(id);
            ListaDeClubes.Remove(clubeRemover);

            return
        }
    }
}
