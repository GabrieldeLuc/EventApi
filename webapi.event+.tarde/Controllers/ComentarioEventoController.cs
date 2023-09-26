using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController(IComentarioEventoRepository comentarioEventoRepository)
        {
            _comentarioEventoRepository = comentarioEventoRepository;
        }

        // POST: api/ComentarioEvento
        [HttpPost]
        public IActionResult Post([FromBody] ComentarioEvento comentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.AdicionarComentario(comentarioEvento);
                return StatusCode(201, "Comentário no evento adicionado com sucesso.");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao adicionar comentário no evento {e.Message}");
            }
        }

       
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                ComentarioEvento comentarioEvento = _comentarioEventoRepository.BuscarComentarioPorId(id);
                if (comentarioEvento != null)
                {
                    return Ok(comentarioEvento);
                }
                return NotFound("Comentário no evento não encontrado.");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao buscar comentário por Id {e.Message}");
            }
        }

      
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ComentarioEvento comentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.AtualizarComentario(id, comentarioEvento);
                return Ok("Comentário Atualizado!.");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao Atualizar Comentário {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.DeletarComentario(id);
                return Ok("Comentário no Evento Deletado.");
            }
            catch (Exception e)
            {
                return BadRequest($"Erro ao Deletar Coméntario no Evento {e.Message}");
            }
        }
    }
}
