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

        public int? Editar(int? idDoEdit, Clube clube)
        {
            
            var Editado = ObterPorId(idDoEdit);
           
            if (clube.Nome != Editado.Nome )
            {
                Editado.Nome = clube.Nome;
            }
            if (clube.Fundacao != Editado.Fundacao);
            {
                Editado.Fundacao = clube.Fundacao;
            }
            if (clube.Estadio != null)
            {
                Editado.Estadio = clube.Estadio;
            }
            if (clube.Estado != Editado.Estado)
            {
                Editado.Estado = clube.Estado;
            }
            if (clube.CoberturaAntiChuva == false)
            {
                Editado.CoberturaAntiChuva = false;
            }
            if (clube.CoberturaAntiChuva == true)
            {
                Editado.CoberturaAntiChuva = true;
            }
            if (clube.Elenco != null)
            {
                Editado.Elenco = clube.Elenco;
            }

            return Editado.Id;


        }
    }
}
