
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
        public List<Jogador> ObterTodos(Filtro? filtro)
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
            string mensagem = null;
            string separador = "\n";
            if (!resultado.IsValid)
            {
                mensagem = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new ValidationException(mensagem);
            }
            int IdNovoJogador = repositoryJogador.Criar(jogador);

            return IdNovoJogador;
        }

        public void EditarJogador(Jogador jogador)
        {
            ValidationResult resultado = validadorJogador.Validate(jogador, options => options.IncludeRuleSets("Editar"));


            string mensagem = null;
            string separador = "\n";
            if (!resultado.IsValid)
            {
                mensagem = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new ValidationException(mensagem);
            }
            repositoryJogador.Editar(jogador);
        }

        public void RemoverJogador(int id )
        {
            repositoryJogador.Remover(id);
        }
    }
}
