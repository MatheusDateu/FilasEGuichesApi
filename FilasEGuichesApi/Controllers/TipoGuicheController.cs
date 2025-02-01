using FilasEGuichesApi.Models;
using FilasEGuichesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilasEGuichesApi.Controllers
{
    [ApiController]
    [Route("api/gerencia/tiposguiche")]
    public class TipoGuicheController : ControllerBase
    {
        private readonly ITipoGuicheService _tipoGuicheService;

        public TipoGuicheController(ITipoGuicheService tipoGuicheService)
        {
            _tipoGuicheService = tipoGuicheService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoGuiche>>> ObterTodos()
        {
            return Ok(await _tipoGuicheService.ObterTodosAsync());
        }

        [HttpPost]
        public async Task<ActionResult<TipoGuiche>> CriarTipoGuiche(TipoGuiche tipoGuiche)
        {
            var novoTipoGuiche = await _tipoGuicheService.CriarAsync(tipoGuiche);
            return CreatedAtAction(nameof(ObterTodos), new { id = novoTipoGuiche.Id }, novoTipoGuiche);
        }
    }
}
