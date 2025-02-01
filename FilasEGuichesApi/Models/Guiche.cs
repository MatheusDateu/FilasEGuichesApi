using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilasEGuichesApi.Models
{
    public class Guiche
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TipoGuicheId { get; set; }

        [ForeignKey("TipoGuicheId")] public TipoGuiche? TipoGuiche { get; set; }

        // Relacionamento
        [JsonIgnore]
        public ICollection<Ficha> Fichas { get; set; } = new List<Ficha>();
    }
}
