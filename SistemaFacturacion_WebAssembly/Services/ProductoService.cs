using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models.DTO;
using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class ProductoService : BaseService, IProductoService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private string _productoURL;
        public ProductoService(IHttpClientFactory httpClientFactory,IConfiguration configuracion):base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _productoURL = configuracion.GetValue<string>("ServiceUrls:API_URL");
        }

        public Task<APIResponse> Crear<T>(ProductoCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"{_productoURL}/api/Producto"
            });
        }
        public Task<APIResponse> Actualizar<T>(ProductoUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"{_productoURL}/api/Producto/{dto.Articulonro}"
            });
        }

        public Task<APIResponse> Obtener<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_productoURL}/api/Producto/{id}"
            });
        }

        public Task<APIResponse> ObtenerTodos<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_productoURL}/api/Producto"
            });
        }

        public Task<APIResponse> Eliminar<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"{_productoURL}/api/Producto/{id}"
            });
        }
    }
}
