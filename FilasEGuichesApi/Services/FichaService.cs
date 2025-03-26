using FilasEGuichesApi.Data.Repository;
using FilasEGuichesApi.Models;

namespace FilasEGuichesApi.Services
{
    public class FichaService : IFichaService
    {
        #region Propriedades

        #region Injeções de Dependências

        private readonly ICrudRepository<Ficha> _fichaRepository;
        private readonly ICrudRepository<Guiche> _guicheRepository;
        private readonly ICrudRepository<TipoGuiche> _tipoGuicheRepository;

        #endregion

        #endregion

        #region Construtores

        public FichaService(
            ICrudRepository<Ficha> fichaRepository,
            ICrudRepository<Guiche> guicheRepository,
            ICrudRepository<TipoGuiche> tipoGuicheRepository)
        {
            _fichaRepository = fichaRepository;
            _guicheRepository = guicheRepository;
            _tipoGuicheRepository = tipoGuicheRepository;
        }

        #endregion

        #region Serviços

        public async Task<IEnumerable<Ficha>> ObterTodasAsync()
        {
            return await _fichaRepository.ObterTodosAsync();
        }

        public async Task<Ficha> ObterPorIdAsync(int id)
        {
            return await _fichaRepository.ObterPorIdAsync(id);
        }

        public async Task<Ficha> CriarAsync(int guicheId)
        {
            var tipoGuiche = await _tipoGuicheRepository.ObterPorIdAsync(guicheId);
            if (tipoGuiche == null) throw new KeyNotFoundException("Tipo de Guichê não encontrado.");

            // Obter a última ficha gerada para esse tipo de guichê
            var ultimasFichas = await _fichaRepository.ObterTodosAsync();
            var ultimaFicha = ultimasFichas
                .Where(f => f.Guiche?.TipoGuicheId == tipoGuiche.Id)
                .OrderByDescending(f => f.Codigo)
                .FirstOrDefault();

            // Gerar o próximo código da ficha
            int proximoNumero = 1;
            if (ultimaFicha != null)
            {
                string numeroAtualStr = ultimaFicha.Codigo.Substring(1); // Remove o prefixo
                if (int.TryParse(numeroAtualStr, out int numeroAtual))
                {
                    proximoNumero = numeroAtual + 1;
                }
            }

            string codigoFicha = $"{tipoGuiche.Prefixo}{proximoNumero:D4}";

            // Criar a nova ficha
            var novaFicha = new Ficha
            {
                Codigo = codigoFicha,
                GuicheId = guicheId
            };

            await _fichaRepository.AdicionarAsync(novaFicha);
            await _fichaRepository.SalvarAsync();

            return novaFicha;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var ficha = await _fichaRepository.ObterPorIdAsync(id);
            if (ficha == null) return false;

            _fichaRepository.Deletar(ficha);
            await _fichaRepository.SalvarAsync();
            return true;
        }

        #endregion
    }
}
