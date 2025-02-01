using FilasEGuichesApi.Data;
using FilasEGuichesApi.Data.Repository;
using FilasEGuichesApi.DTOs;
using FilasEGuichesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilasEGuichesApi.Services
{
    public class GuicheService : IGuicheService
    {
        private readonly ICrudRepository<Guiche> _guicheRepository;
        private readonly ICrudRepository<TipoGuiche> _tipoGuicheRepository;
        private readonly AppDbContext _context;

        public GuicheService(ICrudRepository<Guiche> guicheRepository, ICrudRepository<TipoGuiche> tipoGuicheRepository, AppDbContext context)
        {
            _guicheRepository = guicheRepository;
            _tipoGuicheRepository = tipoGuicheRepository;
            _context = context;
        }

        public async Task<IEnumerable<Guiche>> ObterTodosAsync()
        {
            return await _guicheRepository.ObterTodosAsync();
        }

        /// <summary>
        /// Obter guichês na versão DTO
        /// </summary>
        /// <param name="comoDtos">Forma simplificada de Guiche</param>
        /// <returns>Enumeração de <seealso cref="GuicheConsultaDto"/></returns>
        /// <exception cref="Exception">Não use esta sobrecarga se não deseja obter apenas os DTOs.</exception>
        public async Task<IEnumerable<GuicheConsultaDto>> ObterTodosComoDtoAsync()
        {
            var guiches = await _guicheRepository.ObterTodosAsync();

            return GuicheConsultaDto.DeListaDeEntidades(guiches);
        }

        public async Task<Guiche> ObterPorIdAsync(int id)
        {
            return await _guicheRepository.ObterPorIdAsync(id);
        }

        public async Task<GuicheConsultaDto> CriarAsync(GuicheCriacaoDto guicheDeCriacao)
        {
            var tipoGuicheExistente = await _tipoGuicheRepository.ObterPorIdAsync(guicheDeCriacao.TipoGuicheId);

            if (tipoGuicheExistente is null)
            {
                throw new KeyNotFoundException("O TipoGuiche especificado não existe.");
            }

            var guicheModel = new Guiche()
            {
                TipoGuicheId = guicheDeCriacao.TipoGuicheId,
                TipoGuiche = tipoGuicheExistente
            };

            await _guicheRepository.AdicionarAsync(guicheModel);
            await _guicheRepository.SalvarAsync();

            return GuicheConsultaDto.DeEntidade(guicheModel);
        }

        public async Task<bool> AtualizarAsync(int id, Guiche guiche)
        {
            var guicheExistente = await _guicheRepository.ObterPorIdAsync(id);
            if (guicheExistente == null) return false;

            guicheExistente.TipoGuicheId = guiche.TipoGuicheId;
            _guicheRepository.Atualizar(guicheExistente);
            await _guicheRepository.SalvarAsync();
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var guiche = await _guicheRepository.ObterPorIdAsync(id);
            if (guiche == null) return false;

            _guicheRepository.Deletar(guiche);
            await _guicheRepository.SalvarAsync();
            return true;
        }

        public async Task<int> ObterQuantidadeAsync(int? tipoGuicheId = null)
        {
            if (tipoGuicheId.HasValue)
            {
                return await _context.Guiches.Where(guiche_ => guiche_.TipoGuicheId == tipoGuicheId).CountAsync();
            }

            return await _context.Guiches.CountAsync();
        }
    }
}