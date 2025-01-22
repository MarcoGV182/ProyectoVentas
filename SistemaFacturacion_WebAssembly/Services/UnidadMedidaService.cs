using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Services.IServices;
using System.Net.Http;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class UnidadMedidaService : BaseService, IUnidadMedidaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UnidadMedidaService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<APIResponse> Crear<T>(UnidadMedidaCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/UnidadMedida"
            });
        }
        public Task<APIResponse> Actualizar<T>(int id, UnidadMedidaCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/UnidadMedida/{id}"
            });
        }

        public Task<APIResponse> Obtener<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/UnidadMedida/{id}"
            });
        }

        public Task<APIResponse> ObtenerTodos<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/UnidadMedida"
            });
        }

        public Task<APIResponse> Eliminar<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/UnidadMedida/{id}"
            });
        }
    }
}
