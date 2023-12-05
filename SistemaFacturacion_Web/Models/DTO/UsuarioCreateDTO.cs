using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Web.Models.DTO
{
    public class UsuarioCreateDTO
    {      
        public int UsuarioId { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }        
        public string? Correo { get; set; }
    }
}
