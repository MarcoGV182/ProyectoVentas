using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;


namespace SistemaFacturacion_WebAssembly.Services
{
    public class MarcaService : BaseService, IMarcaService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MarcaService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<MarcaDTO>> Crear(MarcaCreateDTO dto)
        {
            var result = await SendAsync<MarcaDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Marca"
            });
                      

            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id, MarcaCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Marca/{id}"
            });

           

            return result;
        }

        public async Task<APIResponse<MarcaDTO>> Obtener(int id)
        {   
            var result = await SendAsync<MarcaDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Marca/{id}"

            });

          

            return result;
        }

        public async Task<APIResponse<List<MarcaDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<MarcaDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Marca"
            });

          

            return result;
        }

        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Marca/{id}"
            });

          

            return result;
        }
    }
}
