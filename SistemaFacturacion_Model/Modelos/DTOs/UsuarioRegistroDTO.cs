using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class UsuarioRegistroDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string DireccionEmail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
