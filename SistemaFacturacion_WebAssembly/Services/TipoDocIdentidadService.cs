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

        public async Task<APIResponse<TablaMenorDTO>> Crear(TablaMenorCreateDTO dto)
        {
            var result = await SendAsync<TablaMenorDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/TipoDocumentoIdentidad"
            });

         
            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id, TablaMenorCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/TipoDocumentoIdentidad/{id}"
            });

         

            return result;
        }

        public async Task<APIResponse<TablaMenorDTO>> Obtener(int id)
        {
            var result = await SendAsync<TablaMenorDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoDocumentoIdentidad/{id}"

            });

           

            return result;
        }

        public async Task<APIResponse<List<TablaMenorDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<TablaMenorDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoDocumentoIdentidad"
            });

         


            return result;
        }

        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/TipoDocumentoIdentidad/{id}"
            });

          

            return result;
        }
    }
}
