using FilasEGuichesApi.DTOs;
using FilasEGuichesApi.Models;

namespace FilasEGuichesApi.Services
{
    public interface IGuicheService
    {
        Task<IEnumerable<Guiche>> ObterTodosAsync();
        Task<IEnumerable<GuicheConsultaDto>> ObterTodosComoDtoAsync();
        Task<Guiche> ObterPorIdAsync(int id);
        Task<int> ObterQuantidadeAsync(int? tipoGuicheId = null);
        Task<GuicheConsultaDto> CriarAsync(GuicheCriacaoDto guiche);
        Task<bool> AtualizarAsync(int id, Guiche guiche);
        Task<bool> DeletarAsync(int id);
    }
}
