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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get (Guid id)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarPorId(id);

                if (usuario != null) 
                {
                    return Ok(usuario);
                }
                return NotFound("Usuario não encontrado"); 
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao buscar Usuario!{e.Message}"); 
            }
        }

        [HttpPut("{id}")]
            public IActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepository.AtualizarPorId(id, usuario);
                return Ok("Usuario Atualizado com Sucesso"); 
            }
            catch (Exception e) 
            {

                return BadRequest($"Erro ao atualizar Usuario{e.Message}"); 
            }
        }

        [HttpDelete("{id}")] 
        public IActionResult Delete(Guid id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return Ok("Usuario deletado com sucesso"); 
            }
            catch (Exception e) 
            {

                return BadRequest($"Erro ao deletar usuario`. {e.Message}"); 
            }
        }


    } 
}
