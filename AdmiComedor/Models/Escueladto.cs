using System.ComponentModel.DataAnnotations;

namespace AdmiComedor.Models
{
    public class Escueladto
    {

        [Required]
        public string NombreEscuela { get; set; } = "";

        [Required]
        public string Estado { get; set; } = "";
    }
}
