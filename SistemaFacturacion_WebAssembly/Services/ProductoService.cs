using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Services.IServices;
using SistemaFacturacion_Model.Modelos.DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class ProductoService : BaseService, IProductoService
    {
        public readonly IHttpClientFactory _httpClientFactory;
        private string _productoURL;
        private readonly ILogger<ProductoService> _logger;

        public ProductoService(IHttpClientFactory httpClientFactory,IConfiguration configuracion, ILogger<ProductoService> logger) :base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _productoURL = configuracion.GetValue<string>("ServiceUrls:API_URL");
            _logger = logger;
        }

        public async Task<APIResponse<ProductoDTO>> Crear(ProductoCreateDTO dto)
        {
            var result = await SendAsync<ProductoDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.POST,
                Datos = dto,
                URL = $"{_productoURL}/api/Producto"
            });

            return result;
        }
        public async Task<APIResponse<object>> Actualizar(int id,ProductoUpdateDTO dto)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.PUT,
                Datos = dto,
                URL = $"{_productoURL}/api/Producto/{id}"
            });


            return result;
        }

        public async Task<APIResponse<ProductoDTO>> Obtener(int id)
        {
            var result = await SendAsync<ProductoDTO>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_productoURL}/api/Producto/{id}"
            });


            return result;
        }

        public async Task<APIResponse<List<ProductoDTO>>> ObtenerTodos()
        {
            var result = await SendAsync<List<ProductoDTO>>(new APIRequest()
            {
                Tipo = DS.APITipo.GET,
                URL = $"{_productoURL}/api/Producto"
            });
           

            return result;
        }

        public async Task<APIResponse<object>> Eliminar(int id)
        {
            var result = await SendAsync<object>(new APIRequest()
            {
                Tipo = DS.APITipo.DELETE,
                URL = $"{_productoURL}/api/Producto/{id}"
            });
                        

            return result;
        }


        public async Task<APIResponse<StockDTO>> ObtenerStock(int idProducto, int ubicacionId)
        {
            var response = new APIResponse<StockDTO>();

            try
            {
                var request = new APIRequest()
                {
                    Tipo = DS.APITipo.GET,
                    URL = $"{_productoURL}/api/Stock/ObtenerCantidadDisponible?productoId={idProducto}&ubicacionId={ubicacionId}"
                };

                response = await SendAsync<StockDTO>(request);
            }
            catch (Exception ex)
            {
                // 6. Manejo de errores y logging
                response.isExitoso = false;
                response.ErrorMessages = new List<string> { ex.Message };
                _logger.LogError(ex, "Error obteniendo stock para producto {ProductoId}", idProducto);
            }

            return response;

        }
    }
}
