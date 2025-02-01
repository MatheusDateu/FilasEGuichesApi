using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilasEGuichesApi.Models
{
    public class TipoGuiche
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; } // Atendimento, Gerência, etc.

        [Required]
        [StringLength(2)]
        public string Prefixo { get; set; } // Ex.: "A" para Atendimento, "G" para Gerência

        // Relacionamento
        [JsonIgnore]
        public ICollection<Guiche> Guiches { get; set; } = new List<Guiche>();
    }
}
