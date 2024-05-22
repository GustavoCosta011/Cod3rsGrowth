using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoJogador : IServicoJogador
    {
        private readonly IRepositoryData<Jogador> repositoryMockJogador;

        public ServicoJogador(IRepositoryData<Jogador> repositoryMock)
        {
            repositoryMockJogador= repositoryMock;
        }
        public List<Jogador> ObterTodos()
        {
            return repositoryMockJogador.ObterTodos();
        }

        public Jogador ObterPorId(int id)
        {
            return repositoryMockJogador.ObterPorId(id);
        }

        public Jogador CriarJogador(Jogador jogador)
        {
            return repositoryMockJogador.Criar(jogador);
        }
    }
}
