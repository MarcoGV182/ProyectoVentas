using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ClienteService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<ClienteDTO>> Crear(ClienteCreateDTO dto)
        {
            var result = await SendAsync<ClienteDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Cliente"
            });

            
            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id, ClienteCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Cliente/{id}"
            });

           

            return result;
        }

        public async Task<APIResponse<ClienteDTO>> Obtener(int id)
        {   
            var result = await SendAsync<ClienteDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Cliente/{id}"

            });

         

            return result;
        }

        public async Task<APIResponse<List<ClienteDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<ClienteDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Cliente"
            });

          

            return result;
        }

        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Cliente/{id}"
            });

           
            return result;
        }
    }
}
