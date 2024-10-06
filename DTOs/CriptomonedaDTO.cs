using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ParcialWebApi.DTOs
{
    public class CriptomonedaDTO
    {
        //public int Id { get; set; }

        //public string Nombre { get; set; }

        //[JsonIgnore]
        //public string Simbolo { get; set; }

        [Required]
        public double ValorActual { get; set; }

        [Required]
        public DateTime UltimaActualizacion { get; set; }

        [Required]
        public int Categoria { get; set; }

        //public string Estado { get; set; }
    }
}
