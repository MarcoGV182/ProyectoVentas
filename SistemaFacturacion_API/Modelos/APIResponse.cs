using System.Net;

namespace SistemaFacturacion_API.Modelos
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool isExitoso { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public Object Resultado { get; set; }
    }
}
