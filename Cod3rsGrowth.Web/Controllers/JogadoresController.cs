using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Servicos;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        private readonly ServicoJogador _servicoJogador;
        public JogadoresController(ServicoJogador servicoJogador)
        {
            _servicoJogador = servicoJogador;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] Filtro? filtro)
        {
            return Ok(_servicoJogador.ObterTodos(filtro));
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorID([FromRoute] int id)
        {
            var jogador = _servicoJogador.ObterPorId(id);
            if (jogador == null) return NotFound();
            return Ok(jogador);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Jogador objeto)
        {
            return Ok(_servicoJogador.CriarJogador(objeto));
        }

        [HttpPut("{id}")]
        public IActionResult Editar([FromRoute] int id, [FromBody] Jogador objeto)
        {
            try
            {
                objeto.Id = id;
                _servicoJogador.EditarJogador( objeto);
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
        [HttpDelete("{id}")]
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

