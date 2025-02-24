using Newtonsoft.Json;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Pages.Mantenimiento.Productos;
using SistemaFacturacion_WebAssembly.Pages.Mantenimiento.Servicios;
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
            var producto = await _productoService.Obtener<ProductoDTO>(id);
            if (producto != null)
                return (ProductoDTO)producto.Resultado;

            var servicio = await _servicioService.Obtener<ServicioDTO>(id);
            return (ServicioDTO)servicio.Resultado;
        }

        public async Task<List<ArticuloDTO>> ObtenerTodos()
        {
            List<ProductoDTO> listaproductos = new List<ProductoDTO>();
            List<ServicioDTO> listaservicios = new List<ServicioDTO>();


            var result = await _productoService.ObtenerTodos<List<ProductoDTO>>();
            if (result.isExitoso)
            {
                listaproductos = (List<ProductoDTO>)result.Resultado!;
            }

            result = await _servicioService.ObtenerTodos<List<ServicioDTO>>();
            if (result.isExitoso)
            {
                listaservicios = (List<ServicioDTO>)result.Resultado!;
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
