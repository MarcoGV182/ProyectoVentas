using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Models.DTO;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class UsuarioService: BaseService, IUsuarioService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UsuarioService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public Task<APIResponse> Crear<T>(UsuarioCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"api/Usuario"
            });
        }
        public Task<APIResponse> Actualizar<T>(UsuarioDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"api/Usuario/{dto.UsuarioId}"
            });
        }

        public Task<APIResponse> IniciarSesion<T>(UsuarioLogin login)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = login,
                URL = $"api/Usuario/IniciarSesion"
            });
        }

        public Task<APIResponse> ObtenerTodos<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"api/Usuario"
            });
        }

        public Task<APIResponse> Eliminar<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"api/Usuario/{id}"
            });
        }
    }
}
