using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
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

        public async Task<APIResponse<TipoImpuestoDTO>> Obtener(int id)
        {
            var result = await SendAsync<TipoImpuestoDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoImpuesto/{id}"
            });

           

            return result;
        }

        public async Task<APIResponse<List<TipoImpuestoDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<TipoImpuestoDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoImpuesto"
            });

          

            return result;
        }


        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/TipoImpuesto/{id}"
            });

        

            return result;
        }

        public async Task<APIResponse<TipoImpuestoDTO>> Crear(TipoImpuestoCreateDTO dto)
        {
            var result = await SendAsync<TipoImpuestoDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/TipoImpuesto"
            });

          

            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id,TipoImpuestoCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/TipoImpuesto/{id}"
            });

           

            return result;
        }

    }
}
