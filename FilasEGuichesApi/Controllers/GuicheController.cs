using FilasEGuichesApi.DTOs;
using FilasEGuichesApi.Models;
using FilasEGuichesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilasEGuichesApi.Controllers
{
    [ApiController]
    [Route("api/gerencia/guiches")]
    public class GuicheController : ControllerBase
    {
        private readonly IGuicheService _guicheService;

        public GuicheController(IGuicheService guicheService)
        {
            _guicheService = guicheService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guiche>>> ObterTodos()
        {
            var guiches = await _guicheService.ObterTodosAsync();

            bool guicheEhNulo = guiches == null;
            bool guichesEstaVazio = guiches.Any() == false; // 'existe algum item' é falso
            bool noContent = guicheEhNulo || guichesEstaVazio;
            
            if (noContent) 
            {
                return NoContent();
            }

            return Ok(guiches);
        }

        [HttpPost]
        public async Task<ActionResult<Guiche>> CriarGuiche(GuicheCriacaoDto guiche)
        {
            var novoGuiche = await _guicheService.CriarAsync(guiche);
            return CreatedAtAction(nameof(ObterTodos), new { id = novoGuiche.Id }, novoGuiche);
        }
    }
}
