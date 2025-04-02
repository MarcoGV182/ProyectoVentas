using Newtonsoft.Json;
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


        public async Task<APIResponse<T>> Crear<T>(UnidadMedidaCreateDTO dto)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/UnidadMedida"
            });

            return result;
        }
        public async Task<APIResponse<T>> Actualizar<T>(int id, UnidadMedidaCreateDTO dto)
        {
            return await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/UnidadMedida/{id}"
            });
        }

        public async Task<APIResponse<T>> Obtener<T>(int id)
        {
            return await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/UnidadMedida/{id}"
            });
        }

        public async Task<APIResponse<T>> ObtenerTodos<T>()
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/UnidadMedida"
            });

           

            return result;
        }

        public async Task<APIResponse<T>> Eliminar<T>(int id)
        {
            return await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/UnidadMedida/{id}"
            });
        }
    }
}
