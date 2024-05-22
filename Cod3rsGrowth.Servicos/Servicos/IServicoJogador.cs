using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public interface IServicoJogador
    {
        List<Jogador> ObterTodos();
        int CriarJogador(Jogador objeto);
        Jogador ObterPorId(int id);
    }
}
