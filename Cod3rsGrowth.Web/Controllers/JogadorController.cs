using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Servicos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogadorController : ControllerBase
    {
        private readonly ServicoJogador _servicoJogador;
        public JogadorController(ServicoJogador servicoJogador)
        {
            _servicoJogador = servicoJogador;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] Filtro? filtro)
        {
            try
            {
                return Ok(_servicoJogador.ObterTodos(filtro));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorID([FromRoute]int id)
        {
            try
            {
                var jogador = _servicoJogador.ObterPorId(id);
                if (jogador == null) return NotFound();
                return Ok(jogador);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Criar([FromBody] Jogador objeto)
        {
            try
            {
                return Ok(_servicoJogador.CriarJogador(objeto));
            }
            catch (ValidationException excecao)
            {
                return BadRequest(excecao.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Editar([FromRoute]int id, [FromBody]Jogador objeto)
        {
            try
            {
                _servicoJogador.EditarJogador(id,objeto);
                return NoContent();
            }
            catch (ValidationException excecao)
            {
                return BadRequest(excecao.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Remover([FromRoute] int id)
        {
            try
            {
                _servicoJogador.RemoverJogador(id);
                return NotFound();
            }
            catch (ValidationException excecao)
            {
                return BadRequest(excecao.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
