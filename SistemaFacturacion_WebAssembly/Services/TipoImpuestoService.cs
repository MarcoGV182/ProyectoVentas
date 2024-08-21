using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Models.DTO;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class TipoImpuestoService:BaseService,ITipoImpuestoService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        public TipoImpuestoService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task<APIResponse> Obtener<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoImpuesto/{id}"
            });
        }

        public Task<APIResponse> ObtenerTodos<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoImpuesto"
            });
        }


        public Task<APIResponse> Eliminar<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/TipoImpuesto/{id}"
            });
        }

        public Task<APIResponse> Crear<T>(TipoImpuestoCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/TipoImpuesto"
            });
        }
        public Task<APIResponse> Actualizar<T>(int id,TipoImpuestoCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/TipoImpuesto/{id}"
            });
        }

    }
}
