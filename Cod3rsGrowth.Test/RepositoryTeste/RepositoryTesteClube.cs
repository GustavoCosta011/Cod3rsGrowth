using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Test.Singletons.Singleton;


namespace Cod3rsGrowth.Test.RepositoriosTeste
{
    public class RepositoryTesteClube : IRepositoryData<Clube>
    {
        public List<Clube>? ListaDeClubes = ClasseSingleton.Instance.Clubes;
        public Clube? clube;

        public List<Clube> ObterTodos(Filtro? filtro)
        {
            if (filtro == null) return ListaDeClubes;
            var clubes = ListaDeClubes.AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Nome)) clubes = clubes.Where(clube => clube.Nome.Contains(filtro.Nome, StringComparison.OrdinalIgnoreCase));
            if (filtro.Estado.HasValue) clubes = clubes.Where(clube => clube.Estado == filtro.Estado);
            if (filtro.DataPiso.HasValue) clubes = clubes.Where(clube => clube.Fundacao >= filtro.DataPiso);
            if (filtro.DataTeto.HasValue) clubes = clubes.Where(clube => clube.Fundacao <= filtro.DataTeto);

            return clubes.ToList();
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

        public void Editar(Clube clube)
        {

            var ClubeAEditar = ObterPorId(clube.Id);

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