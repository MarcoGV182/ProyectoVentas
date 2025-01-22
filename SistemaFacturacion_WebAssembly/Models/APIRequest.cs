using static SistemaFacturacion_Utilidad.DS;

namespace SistemaFacturacion_WebAssembly.Models
{
    public class APIRequest
    {
        public APITipo Tipo { get; set; } = APITipo.GET;

        public string URL { get; set; }
        public object Datos { get; set; }
        public string Token { get; set; }
    }
}
