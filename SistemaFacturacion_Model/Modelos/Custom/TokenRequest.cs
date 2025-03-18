using System.ComponentModel.DataAnnotations;

namespace SistemaFacturacion_Model.Modelos.Custom
{
    public class TokenRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
