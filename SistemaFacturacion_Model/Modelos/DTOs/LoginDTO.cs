using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.DTOs
{
    public class LoginDTO
    {   
        public string UserName { get; set; }
        [Required(ErrorMessage = "La dirección de correo es requerida")]
        [EmailAddress(ErrorMessage ="El formato de la direccion de correo no es válida")]
        public string DireccionEmail { get; set; }
        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
    }
}
