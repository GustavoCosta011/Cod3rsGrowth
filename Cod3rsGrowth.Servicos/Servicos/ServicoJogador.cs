
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Validadores;
using Cod3rsGrowth.Dominio.Interfaces;
using FluentValidation;
using FluentValidation.Results;


namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoJogador
    {
        private readonly IRepositoryData<Jogador> repositoryJogador;
        private readonly ValidadorJogador validadorJogador;
        public ServicoJogador(IRepositoryData<Jogador> repositoryMock, ValidadorJogador validador)
        {
            repositoryJogador = repositoryMock;
            validadorJogador = validador;     
        }
        public List<Jogador> ObterTodos(IFiltro filtro)
        {
            return repositoryJogador.ObterTodos(filtro);
        }

        public Jogador ObterPorId(int id)
        {
            return repositoryJogador.ObterPorId(id);
        }

        public int CriarJogador(Jogador jogador)
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

            int IdNovoJogador = repositoryJogador.Criar(jogador);




            return IdNovoJogador;

        }

        public void EditarJogador(int id, Jogador jogador)
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
            repositoryJogador.Editar(id, jogador);
        }

        public void RemoverJogador(int id )
        {
            repositoryJogador.Remover(id);
        }
    }
}
