using System.Net;

namespace SistemaFacturacion_Utilidad
{
    public class APIResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool isExitoso { get; set; } = false;
        public List<string> ErrorMessages { get; set; }
        public T Resultado { get; set; }
    }
}
