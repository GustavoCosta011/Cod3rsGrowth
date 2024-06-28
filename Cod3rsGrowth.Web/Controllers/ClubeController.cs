using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Servicos;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubeController : ControllerBase
    {
        private readonly ServicoClube _servicoClube;
        public ClubeController(ServicoClube servicoClube)
        {
            _servicoClube = servicoClube;
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] Filtro? filtro)
        {
            try
            {
                return Ok(_servicoClube.ObterTodos(filtro));
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
                var clube = _servicoClube.ObterPorId(id);
                if (clube == null) return NotFound();
                return Ok(clube);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Criar([FromBody] Clube objeto)
        {
            try
            {
                return Ok(_servicoClube.CriarClube(objeto));
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
        public IActionResult Editar([FromRoute]int id, [FromBody]Clube objeto)
        {
            try
            {
                _servicoClube.EditarClube(id,objeto);
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
                _servicoClube.RemoverClube(id);
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
