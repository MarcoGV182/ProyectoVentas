using SistemaFacturacion_Utilidad;
using SistemaFacturacion_Web.Models.DTO;
using SistemaFacturacion_Web.Models;
using SistemaFacturacion_Web.Services.IServices;

namespace SistemaFacturacion_Web.Services
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

        public Task<T> Crear<T>(ProductoCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"{_productoURL}/api/Producto"
            });
        }
        public Task<T> Actualizar<T>(ProductoUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"{_productoURL}/api/Producto/{dto.Articulonro}"
            });
        }

        public Task<T> Obtener<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_productoURL}/api/Producto/{id}"
            });
        }

        public Task<T> ObtenerTodos<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_productoURL}/api/Producto"
            });
        }

        public Task<T> Eliminar<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"{_productoURL}/api/Producto/{id}"
            });
        }
    }
}
