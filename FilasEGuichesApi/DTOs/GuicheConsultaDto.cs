using FilasEGuichesApi.Models;

namespace FilasEGuichesApi.DTOs
{
    public record GuicheConsultaDto(
        int Id,
        int TipoGuicheId,
        string TipoGuicheNome)
    {

        /// <summary>
        /// Método para converter um único Guiche em GuicheConsultaDto
        /// </summary>
        /// <param name="guiche"></param>
        /// <returns></returns>
        public static GuicheConsultaDto DeEntidade(Guiche guiche)
        {
            return new GuicheConsultaDto(
                Id: guiche.Id,
                TipoGuicheId: guiche.TipoGuicheId,
                TipoGuicheNome: guiche.TipoGuiche.Nome
            );
        }

        /// <summary>
        /// Método para converter uma lista de Guiche para uma lista de GuicheConsultaDto
        /// </summary>
        /// <param name="guiches"></param>
        /// <returns></returns>
        public static IEnumerable<GuicheConsultaDto> DeListaDeEntidades(IEnumerable<Guiche> guiches)
        {
            return guiches.Select(DeEntidade);
        }
    }
}