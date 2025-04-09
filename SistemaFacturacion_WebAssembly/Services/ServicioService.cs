using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;
using SistemaFacturacion_Model.Modelos.DTOs;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class ServicioService : BaseService, IServicioService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private string _productoURL;
        public ServicioService(IHttpClientFactory httpClientFactory,IConfiguration configuracion):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _productoURL = configuracion.GetValue<string>("ServiceUrls:API_URL");
        }

        public async Task<APIResponse<ServicioDTO>> Crear(ServicioCreateDTO dto)
        {
            var result = await SendAsync<ServicioDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"{_productoURL}/api/Servicio"
            });


            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id, ServicioCreateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"{_productoURL}/api/Servicio/{id}"
            });

           

            return result;
        }

        public async Task<APIResponse<ServicioDTO>> Obtener(int id)
        {
            var result = await SendAsync<ServicioDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_productoURL}/api/Servicio/{id}"
            });

            return result;
        }

        public async Task<APIResponse<List<ServicioDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<ServicioDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_productoURL}/api/Servicio"
            });

           

            return result;
        }

        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"{_productoURL}/api/Servicio/{id}"
            });

         

            return result;
        }
    }
}
