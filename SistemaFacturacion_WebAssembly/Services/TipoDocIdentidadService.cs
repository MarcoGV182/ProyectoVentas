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

        public async Task<APIResponse> Crear<T>(TablaMenorCreateDTO dto)
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/TipoDocumentoIdentidad"
            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }
        public async Task<APIResponse> Actualizar<T>(int id, TablaMenorCreateDTO dto)
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/TipoDocumentoIdentidad/{id}"
            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }

        public async Task<APIResponse> Obtener<T>(int id)
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoDocumentoIdentidad/{id}"

            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }

        public async Task<APIResponse> ObtenerTodos<T>()
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoDocumentoIdentidad"
            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());


            return result;
        }

        public async Task<APIResponse> Eliminar<T>(int id)
        {
            var result = await SendAsync<APIResponse>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/TipoDocumentoIdentidad/{id}"
            });

            if (result.isExitoso)
                result.Resultado = JsonConvert.DeserializeObject<T>(result.Resultado.ToString());

            return result;
        }
    }
}
