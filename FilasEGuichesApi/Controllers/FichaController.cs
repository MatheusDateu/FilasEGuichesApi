using FilasEGuichesApi.Models;
using FilasEGuichesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilasEGuichesApi.Controllers
{
    [ApiController]
    [Route("api/gerencia/fichas")]
    public class FichaController : ControllerBase
    {
        private readonly IFichaService _fichaService;

        public FichaController(IFichaService fichaService)
        {
            _fichaService = fichaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ficha>>> ObterTodas()
        {
            var fichas = await _fichaService.ObterTodasAsync();

            bool fichasEhNulo = fichas is null;
            bool fichasEstaVazio = fichas.Any() == false;
            bool noContent = fichasEhNulo || fichasEstaVazio;

            if (noContent)
            {
                return NoContent();
            }

            return Ok(fichas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ficha>> ObterPorId(int id)
        {
            var ficha = await _fichaService.ObterPorIdAsync(id);
            if (ficha == null)
            {
                var dentroDoEscopo = "dentro do if";
                return NotFound();
            }

            return Ok(ficha);
        }

        [HttpPost("{guicheId}")]
        public async Task<ActionResult<Ficha>> CriarFicha(int guicheId)
        {
            var ficha = await _fichaService.CriarAsync(guicheId);
            return CreatedAtAction(nameof(ObterPorId), new { id = ficha.Id }, ficha);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarFicha(int id)
        {
            bool deletado = await _fichaService.DeletarAsync(id);
            if (!deletado) return NotFound();
            return NoContent();
        }
    }
}
