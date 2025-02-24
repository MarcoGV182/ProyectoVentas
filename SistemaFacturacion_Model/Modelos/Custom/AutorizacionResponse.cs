using SistemaFacturacion_Model.Modelos.DTOs;

namespace SistemaFacturacion_Model.Modelos.Custom
{
    public class AutorizacionResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool Resultado { get; set; }
        public List<string> Mensaje { get; set; }
        public UsuarioResponse Usuario { get; set; }
    }
}
