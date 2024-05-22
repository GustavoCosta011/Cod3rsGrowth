
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Validadores;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation.Results;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoJogador : IServicoJogador 
    {
        private readonly IRepositoryData<Jogador> repositoryMockJogador;
        private readonly ValidadorJogador validadorJogador;
        public ServicoJogador(IRepositoryData<Jogador> repositoryMock, ValidadorJogador validador)
        {
            repositoryMockJogador = repositoryMock;
            validadorJogador = validador;     
        }
        public List<Jogador> ObterTodos()
        {
            return repositoryMockJogador.ObterTodos();
        }

        public Jogador ObterPorId(int id)
        {
            return repositoryMockJogador.ObterPorId(id);
        }

        public int CriarJogador(Jogador jogador)
        {
            ValidationResult resultado = validadorJogador.Validate(jogador);
            if (resultado.IsValid) throw new Exception(resultado.Errors.First().ErrorMessage);

            int IdNovoJogador = repositoryMockJogador.Criar(jogador);

            return IdNovoJogador; 
           
            
        }
    }
}
