using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class LoginDTO
    {   
        public string UserName { get; set; }
        [Required(ErrorMessage = "La dirección de correo es requerida")]
        [EmailAddress]
        public string DireccionEmail { get; set; }
        [Required(ErrorMessage = "La constraseña es requerida")]
        public string Password { get; set; }
    }
}
