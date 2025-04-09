using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_WebAssembly.Services.IServices;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly IProductoService _productoService;
        private readonly IServicioService _servicioService;
        

        public ArticuloService(IProductoService productoService, IServicioService servicioService) 
        {
            _productoService = productoService;
            _servicioService = servicioService;
        }

        public async Task<ArticuloDTO> Obtener(int id)
        {
            var producto = await _productoService.Obtener(id);
            if (producto != null)
                return producto.Resultado;

            var servicio = await _servicioService.Obtener(id);
            return servicio.Resultado;
        }

        public async Task<List<ArticuloDTO>> ObtenerTodos(int ubicacion)
        {
            List<ProductoDTO> listaproductos = new List<ProductoDTO>();
            List<ServicioDTO> listaservicios = new List<ServicioDTO>();


            var result = await _productoService.ObtenerTodos();
            if (result.isExitoso)
            {   
                listaproductos = result.Resultado;
                foreach (var item in listaproductos)
                {
                    var apiResponse = await _productoService.ObtenerStock(item.ArticuloId, ubicacion);

                    item.StockActual = apiResponse.isExitoso ? apiResponse.Resultado?.Cantidad ?? 0 : 0;
                }                
            }

            var resultServicio = await _servicioService.ObtenerTodos();
            if (resultServicio.isExitoso)
            {
                listaservicios = resultServicio.Resultado;
            }


            var articulos = new List<ArticuloDTO>();

            // Mapear productos a ArticuloDTO
            articulos.AddRange(listaproductos);

            // Mapear servicios a ArticuloDTO
            articulos.AddRange(listaservicios);

            return articulos;
        }
    }
}
