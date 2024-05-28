
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.InterfacesServicos
{
    public interface IServicoClube
    {
        List<Clube> ObterTodos();

        int CriarClube(Clube clube);
        Clube ObterPorId(int id);
        void EditarClube(int id, Clube clube);
        void RemoverClube(int id);
    }
}
