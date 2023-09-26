using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoRepository _instituicaoRepository;

        public InstituicaoController(IInstituicaoRepository instituicaoRepository)
        {
            _instituicaoRepository = instituicaoRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Cadastrar(instituicao);
                return StatusCode(201, "Instituição Cadastrada com Sucesso.");
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao cadastrar instituição: {e.Message}");
            }
        }

        [HttpGet("{d}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                Instituicao instituicao = _instituicaoRepository.BuscarInstituicaoPorId(id);
                if (instituicao != null)
                {
                    return Ok(instituicao);
                }
                return NotFound("Instituição não encontrada");
            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao buscar instituição por ID: {e.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Atualizar(id, instituicao);
                return Ok("Instituição atualizada com Sucesso.");

            }
            catch (Exception e)
            {

                return BadRequest($"Erro ao Atualizar a Instituição. {e.Message}");
            }
        }

        [HttpDelete] 
        public IActionResult Delete (Guid id)
        {
            try
            {
                _instituicaoRepository.Deletar(id);
                return Ok("Instituição deletada com Sucesso!"); 
            }
            catch (Exception e) 
            {

                return BadRequest($"Erro ao Deletar a Instituição{e.Message}"); 
            }
        }

    }
}
