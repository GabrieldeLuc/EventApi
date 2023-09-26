using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Repositories;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpPost]

        public IActionResult Post(TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(tipoUsuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuario = _tipoUsuarioRepository.BuscarPorId(id);
                if (tipoUsuario != null)
                {
                    return Ok(tipoUsuario);
                }

                return NotFound("Tipo do Usuario não encontrado.");
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao buscar tipo do Usuario por Id {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TipoUsuario tipoUsuario)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, tipoUsuario);
                return Ok("Tipo do Usuario Atualizado com sucesso.");
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao atualizar tipo do Usuario.{e.Message}");
            }
        }

        [HttpDelete("{id}")] 

        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return Ok("Tipo do Usuario deletado."); 
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao deletar tipo do Usuario.{e.Message}" );  
            }
        
        }

    }
}
