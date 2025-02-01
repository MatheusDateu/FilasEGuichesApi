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
            return Ok(await _guicheService.ObterTodosAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Guiche>> CriarGuiche(GuicheCriacaoDto guiche)
        {
            var novoGuiche = await _guicheService.CriarAsync(guiche);
            return CreatedAtAction(nameof(ObterTodos), new { id = novoGuiche.Id }, novoGuiche);
        }
    }
}
