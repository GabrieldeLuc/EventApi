using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class EventoController : ControllerBase
    {
        private IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpPost]
        public IActionResult CadastrarEvento(Evento evento)
        {
            try
            {
                _eventoRepository.Cadastrar(evento);
                return StatusCode(201);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao Cadastrar Evento: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult ListarEventos()
        {
            try
            {
                var eventos = _eventoRepository.ListarEventos();
                return Ok(eventos);
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao Listar os eventos {ex.Message}");
            }
        }

        [HttpGet("{id}/inscricao")]
        public IActionResult inscreverEmEvento(Guid id)
        {
            try
            {
                return Ok("Inscrição realizada com Sucesso!");
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao inscrever Evento{ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Evento evento = _eventoRepository.BuscarEventoPorId(id);
                if (evento != null)
                {
                    return Ok(evento);
                }
                return NotFound("Evento não encontrado");
            }


            catch (Exception e)
            {

                return BadRequest($"Erro ao Buscar Evento por Id {e.Message}");
            }
        }

        [HttpPut("{id}")] 
        public IActionResult Put(Guid id, [FromBody] Evento evento)
        {
            try
            {
                _eventoRepository.Atualizar(id, evento);
                return Ok("Evento Atualizado com sucesso"); 
            }
            catch (Exception e) 
            {

                return BadRequest($"Erro ao atualizar Evento {e.Message}"); 
            }
        }


        [HttpDelete("{id}")] 
        public IActionResult Delete(Guid id) 
        {
            try
            {
                _eventoRepository.Deletar(id);
                return Ok("Evento deletado com sucesso"); 
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao deletar Evento{e.Message}");
            }
        }
    }
}
