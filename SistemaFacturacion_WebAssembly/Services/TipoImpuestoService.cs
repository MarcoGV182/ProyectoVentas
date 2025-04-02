using Newtonsoft.Json;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
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

        public async Task<APIResponse<T>> Obtener<T>(int id)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoImpuesto/{id}"
            });

           

            return result;
        }

        public async Task<APIResponse<T>> ObtenerTodos<T>()
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoImpuesto"
            });

          

            return result;
        }


        public async Task<APIResponse<T>> Eliminar<T>(int id)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/TipoImpuesto/{id}"
            });

        

            return result;
        }

        public async Task<APIResponse<T>> Crear<T>(TipoImpuestoCreateDTO dto)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/TipoImpuesto"
            });

          

            return result;
        }
        public async Task<APIResponse<T>> Actualizar<T>(int id,TipoImpuestoCreateDTO dto)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/TipoImpuesto/{id}"
            });

           

            return result;
        }

    }
}
