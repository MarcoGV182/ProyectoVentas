using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Services.IServices;
using System.Net.Http;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class MarcaService : BaseService, IMarcaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MarcaService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<APIResponse> Crear<T>(MarcaCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Marca"
            });
        }
        public Task<APIResponse> Actualizar<T>(int id, MarcaCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Marca/{id}"
            });
        }

        public Task<APIResponse> Obtener<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Marca/{id}"
            });
        }

        public Task<APIResponse> ObtenerTodos<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Marca"
            });
        }

        public Task<APIResponse> Eliminar<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Marca/{id}"
            });
        }
    }
}
