using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilasEGuichesApi.Models
{
    public class Ficha
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; } // Ex: A0001, G0002

        [Required]
        public int GuicheId { get; set; }

        [ForeignKey("GuicheId")]
        [JsonIgnore]
        public Guiche Guiche { get; set; }
    }
}