using SistemaFacturacion_Utilidad;
using SistemaFacturacion_Web.Models;
using SistemaFacturacion_Web.Services.IServices;

namespace SistemaFacturacion_Web.Services
{
    public class TipoImpuestoService:BaseService,ITipoImpuestoService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private string _tipoImpuestoURL;
        public TipoImpuestoService(IHttpClientFactory httpClientFactory, IConfiguration configuracion) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _tipoImpuestoURL = configuracion.GetValue<string>("ServiceUrls:API_URL");
        }

        public Task<T> Obtener<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_tipoImpuestoURL}/api/TipoImpuesto/{id}"
            });
        }

        public Task<T> ObtenerTodos<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_tipoImpuestoURL}/api/TipoImpuesto"
            });
        }
    }
}
