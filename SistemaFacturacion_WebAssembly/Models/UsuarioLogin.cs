using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_WebAssembly.Models
{
    public class UsuarioLogin
    {
        [Required(ErrorMessage = "El Usuario/Login es requerido.")]
        public string Usuario { get; set; } = null!;

        [Required(ErrorMessage = "La contraseña es requerida.")]
        public string Clave { get; set; } = null!;
    }
}
