using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;


namespace SistemaFacturacion_WebAssembly.Services
{
    public class CiudadService : BaseService, ICiudadService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CiudadService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<CiudadDTO>> Crear(CiudadCreateDTO dto)
        {
            var result = await SendAsync<CiudadDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Ciudad"
            });
                        

            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id, CiudadCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Ciudad/{id}"
            });

           
            return result;
        }

        public async Task<APIResponse<CiudadDTO>> Obtener(int id)
        {   
            var result = await SendAsync<CiudadDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Ciudad/{id}"

            });

            return result;
        }

        public async Task<APIResponse<List<CiudadDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<CiudadDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Ciudad"
            });
       

            return result;
        }

        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Ciudad/{id}"
            });

     
            return result;
        }
    }
}
