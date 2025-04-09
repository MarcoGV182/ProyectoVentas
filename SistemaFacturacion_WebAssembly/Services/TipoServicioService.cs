using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class TipoServicioService : BaseService, ITipoServicioService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TipoServicioService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<TipoServicioDTO>> Crear(TablaMenorCreateDTO dto)
        {
            var result = await SendAsync<TipoServicioDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/TipoServicio"
            });

        

            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id, TablaMenorCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/TipoServicio/{id}"
            });

         

            return result;
        }

        public async Task<APIResponse<TipoServicioDTO>> Obtener(int id)
        {
            var result = await SendAsync<TipoServicioDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoServicio/{id}"

            });


            return result;
        }

        public async Task<APIResponse<List<TipoServicioDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<TipoServicioDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/TipoServicio"
            });

          

            return result;
        }

        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/TipoServicio/{id}"
            });

           
            return result;
        }
    }
}
