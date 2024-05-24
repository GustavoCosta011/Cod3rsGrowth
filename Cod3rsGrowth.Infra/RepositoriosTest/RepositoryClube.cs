using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.Singletons.Testes.Singleton;


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
           return ListaDeClubes.Find(clube => clube.Id == id);
        }
            
        public int? Criar(Clube clube)
        {
            clube.Id = ListaDeClubes.Any() ? ListaDeClubes.Max(clube => clube.Id) + 1 : 1;

            ListaDeClubes.Add(clube);

            return clube.Id;

        }



    }
}
