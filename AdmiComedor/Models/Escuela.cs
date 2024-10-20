using Microsoft.AspNetCore.Identity;

namespace AdmiComedor.Models
{
    public class Escuela
    {
        public int IdEscuelas {get; set;}

        public string NombreEscuela { get; set; } = "";

        public string Estado { get; set; } = "";
    }
}
