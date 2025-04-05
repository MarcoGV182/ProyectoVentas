using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class UsuarioDTO
    {
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }       
        public string Email { get; set; }
        public string Rol { get; set; }
    }
}
