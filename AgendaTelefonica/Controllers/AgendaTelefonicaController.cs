using AgendaTelefonica.Models;
using AgendaTelefonica.Services;
using Microsoft.AspNetCore.Mvc;


namespace AgendaTelefonica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly ContatoService _contatoService;

        public ContatoController(ContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contato>>> GetContatos()
        {
            var contatos = await _contatoService.GetAllAsync();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> GetContato(int id)
        {
            var contato = await _contatoService.GetByIdAsync(id);
            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContato(int id, Contato contato)
        {
            if (id != contato.ContatoId)
            {
                return BadRequest();
            }

            try
            {
                await _contatoService.UpdateAsync(contato);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostContato(Contato contato)
        {
            try
            {
                
                if (string.IsNullOrEmpty(contato.nome) || string.IsNullOrEmpty(contato.Telefone))
                {
                    return BadRequest("Nome e telefone são obrigatórios.");
                }

                await _contatoService.AddAsync(contato); 
                return CreatedAtAction("GetContato", new { id = contato.ContatoId }, contato);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContato(int id)
        {
            try
            {
                await _contatoService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
