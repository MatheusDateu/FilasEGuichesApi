using FilasEGuichesApi.Models;

namespace FilasEGuichesApi.Services
{
    public interface IFichaService
    {
        Task<IEnumerable<Ficha>> ObterTodasAsync();
        Task<Ficha> ObterPorIdAsync(int id);
        Task<Ficha> CriarAsync(int guicheId);
        Task<bool> DeletarAsync(int id);
    }
}
