using Blazored.LocalStorage;
using SistemaFacturacion_Model.Modelos.Custom;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class UsuarioService: BaseService, IUsuarioService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILocalStorageService _localStorageService;

        public UsuarioService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<APIResponse<UsuarioDTO>> Crear(UsuarioRegistroDTO dto)
        {
            var apiRequest = new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Usuario"
            };

            var result = await SendAsync<UsuarioDTO>(apiRequest);

          

            return result;
        }

        public async Task<APIResponse<object>> Actualizar(string id,UsuarioRegistroDTO dto)
        {
            var apiRequest = new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Usuario/{id}"
            };

            var result = await SendAsync<object>(apiRequest);

            

            return result;
        }

        public async Task<APIResponse<AutorizacionResponse>> IniciarSesion(LoginDTO login)
        {
            var apiRequest = new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = login,
                URL = $"api/Usuario/IniciarSesion"
            };

            var result = await SendAsync<AutorizacionResponse>(apiRequest);

            return result;
        }

        public async Task<APIResponse<AutorizacionResponse>> RefrescarToken(TokenRequest tokenRequest)
        {
            var apiRequest = new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = tokenRequest,
                URL = $"api/Usuario/RefreshToken"
            };

            var result = await SendAsync<AutorizacionResponse>(apiRequest);

            return result;
        }

        public async Task<APIResponse<List<UsuarioDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<UsuarioDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Usuario"
            });
           

            return result;
        }

        public async Task<APIResponse<object>> Eliminar(string id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Usuario/{id}"
            });

          

            return result;
        }
    }
}
