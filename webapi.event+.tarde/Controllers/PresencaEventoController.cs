using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PresencaEventoController : ControllerBase
    {
        private readonly IPresencaEventoRepository _presencaEventoRepository;

        public PresencaEventoController(IPresencaEventoRepository presencaEventoRepository)
        {
            _presencaEventoRepository = presencaEventoRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.RegistrarPresenca(presencaEvento);
                return StatusCode(201, "Registro feito com sucesso");


            }
            catch (Exception e)
            {

                throw new Exception($"Erro ao registrar Presença {e.Message}");

            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<PresencaEvento> presencas = _presencaEventoRepository.ListarPresencas();
                return Ok(presencas);

            }
            catch (Exception e)
            {

                throw new Exception($"Erro ao Listar Presenças {e.Message}");
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                PresencaEvento presencaEvento = _presencaEventoRepository.BuscarPresencaPorId(id); 
                if (presencaEvento != null)
                {
                    return Ok(presencaEvento);
                }
                return NotFound("Não foi possível encontrar a Presença");
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao buscar a presença do Evento por Id {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] PresencaEvento presencaEvento)
        {
            try
            {
                _presencaEventoRepository.AtualizarPresenca(id, presencaEvento);
                return Ok("Presença  no eventon Atualizada com Sucesso"); 
            }
            catch (Exception e) 
            {

                return BadRequest($"Erro ao atualizar presença no evento {e.Message}");
            }
        }

        [HttpDelete("{id}")] 
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaEventoRepository.DeletarPresenca(id);
                return Ok("Presença deletada."); 
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao deletar Presença {e.Message}");
            }
        }




        

    }
}
