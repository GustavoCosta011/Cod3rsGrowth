using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Dominio.InterfacesServicos
{
    public interface IServicoJogador
    {
        List<Jogador> ObterTodos();
        int CriarJogador(Jogador objeto);
        Jogador ObterPorId(int id);
        void EditarJogador(int id, Jogador jogador);
        void RemoverJogador(int id);
    }   
}
