using FilasEGuichesApi.Data.Repository;
using FilasEGuichesApi.Models;

namespace FilasEGuichesApi.Services
{
    public class TipoGuicheService : ITipoGuicheService
    {
        private readonly ICrudRepository<TipoGuiche> _tipoGuicheRepository;

        public TipoGuicheService(ICrudRepository<TipoGuiche> tipoGuicheRepository)
        {
            _tipoGuicheRepository = tipoGuicheRepository;
        }

        public async Task<IEnumerable<TipoGuiche>> ObterTodosAsync()
        {
            return await _tipoGuicheRepository.ObterTodosAsync();
        }

        public async Task<TipoGuiche> ObterPorIdAsync(int id)
        {
            return await _tipoGuicheRepository.ObterPorIdAsync(id);
        }

        public async Task<TipoGuiche> CriarAsync(TipoGuiche tipoGuiche)
        {
            await _tipoGuicheRepository.AdicionarAsync(tipoGuiche);
            await _tipoGuicheRepository.SalvarAsync();
            return tipoGuiche;
        }

        public async Task<bool> AtualizarAsync(int id, TipoGuiche tipoGuiche)
        {
            var tipoGuicheExistente = await _tipoGuicheRepository.ObterPorIdAsync(id);
            if (tipoGuicheExistente == null) return false;

            tipoGuicheExistente.Nome = tipoGuiche.Nome;
            tipoGuicheExistente.Prefixo = tipoGuiche.Prefixo;
            _tipoGuicheRepository.Atualizar(tipoGuicheExistente);
            await _tipoGuicheRepository.SalvarAsync();
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var tipoGuiche = await _tipoGuicheRepository.ObterPorIdAsync(id);
            if (tipoGuiche == null) return false;

            _tipoGuicheRepository.Deletar(tipoGuiche);
            await _tipoGuicheRepository.SalvarAsync();
            return true;
        }
    }
}
