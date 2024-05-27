
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Validadores;
using Cod3rsGrowth.Infra.Interfaces;
using FluentValidation;
using FluentValidation.Results;


namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoJogador : IServicoJogador 
    {
        private readonly IRepositoryData<Jogador> repositoryJogador;
        private readonly ValidadorJogador validadorJogador;
        public ServicoJogador(IRepositoryData<Jogador> repositoryMock, ValidadorJogador validador)
        {
            repositoryJogador = repositoryMock;
            validadorJogador = validador;     
        }
        public List<Jogador> ObterTodos()
        {
            return repositoryJogador.ObterTodos();
        }

        public Jogador ObterPorId(int? id)
        {
            return repositoryJogador.ObterPorId(id);
        }

        public int? CriarJogador(Jogador jogador)
        {
            ValidationResult resultado = validadorJogador.Validate(jogador);


            if (!resultado.IsValid)
            {
                string mensagem = null;

                foreach (var erro in resultado.Errors)
                {
                    mensagem += erro.ErrorMessage;

                }

                throw new Exception(mensagem);
            }

            int? IdNovoJogador = repositoryJogador.Criar(jogador);




            return IdNovoJogador;

        }

        public int? EditarJogador(int id,Jogador jogador)
        {
            ValidationResult resultado = validadorJogador.Validate(jogador, options => options.IncludeRuleSets("Editar"));


            if (!resultado.IsValid)
            {
                string mensagem = null;

                foreach (var erro in resultado.Errors)
                {
                    mensagem += erro.ErrorMessage;

                }

                throw new Exception(mensagem);
            }

            int? IdJogadorEditado = repositoryJogador.Editar(id, jogador);




            return IdJogadorEditado;
        }

       
    }
}
