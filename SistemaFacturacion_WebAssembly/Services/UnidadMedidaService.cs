using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class UnidadMedidaService : BaseService, IUnidadMedidaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UnidadMedidaService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<APIResponse<UnidadMedidaDTO>> Crear(UnidadMedidaCreateDTO dto)
        {
            var result = await SendAsync<UnidadMedidaDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/UnidadMedida"
            });

            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id, UnidadMedidaCreateDTO dto)
        {
            return await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/UnidadMedida/{id}"
            });
        }

        public async Task<APIResponse<UnidadMedidaDTO>> Obtener(int id)
        {
            return await SendAsync<UnidadMedidaDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/UnidadMedida/{id}"
            });
        }

        public async Task<APIResponse<List<UnidadMedidaDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<UnidadMedidaDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/UnidadMedida"
            });

           

            return result;
        }

        public async Task<APIResponse<object>> Eliminar(int id)
        {
            return await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/UnidadMedida/{id}"
            });
        }
    }
}
