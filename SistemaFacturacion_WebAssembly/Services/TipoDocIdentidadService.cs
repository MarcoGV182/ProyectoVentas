using Blazored.LocalStorage;
using Newtonsoft.Json;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class TipoDocIdentidadService : BaseService, ITipoDocIdentidadService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TipoDocIdentidadService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<T>> Crear<T>(TablaMenorCreateDTO dto)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/TipoDocumentoIdentidad"
            });

         
            return result;
        }
        public async Task<APIResponse<T>> Actualizar<T>(int id, TablaMenorCreateDTO dto)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/TipoDocumentoIdentidad/{id}"
            });

         

            return result;
        }

        public async Task<APIResponse<T>> Obtener<T>(int id)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoDocumentoIdentidad/{id}"

            });

           

            return result;
        }

        public async Task<APIResponse<T>> ObtenerTodos<T>()
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoDocumentoIdentidad"
            });

         


            return result;
        }

        public async Task<APIResponse<T>> Eliminar<T>(int id)
        {
            var result = await SendAsync<APIResponse<T>>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/TipoDocumentoIdentidad/{id}"
            });

          

            return result;
        }
    }
}
