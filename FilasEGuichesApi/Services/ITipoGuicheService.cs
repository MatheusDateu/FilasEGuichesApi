using FilasEGuichesApi.Models;

namespace FilasEGuichesApi.Services
{
    public interface ITipoGuicheService
    {
        Task<IEnumerable<TipoGuiche>> ObterTodosAsync();
        Task<TipoGuiche> ObterPorIdAsync(int id);
        Task<TipoGuiche> CriarAsync(TipoGuiche tipoGuiche);
        Task<bool> AtualizarAsync(int id, TipoGuiche tipoGuiche);
        Task<bool> DeletarAsync(int id);
    }
}
