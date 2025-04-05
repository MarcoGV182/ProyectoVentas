using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Pages.Mantenimiento.Productos;
using SistemaFacturacion_WebAssembly.Pages.Mantenimiento.Servicios;
using SistemaFacturacion_WebAssembly.Services.IServices;
using System.Collections.Generic;
using System.Text.Json;

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
                return producto.Resultado;

            var servicio = await _servicioService.Obtener<ServicioDTO>(id);
            return servicio.Resultado;
        }

        public async Task<List<ArticuloDTO>> ObtenerTodos(int ubicacion)
        {
            List<ProductoDTO> listaproductos = new List<ProductoDTO>();
            List<ServicioDTO> listaservicios = new List<ServicioDTO>();


            var result = await _productoService.ObtenerTodos<List<ProductoDTO>>();
            if (result.isExitoso)
            {   
                listaproductos = result.Resultado;
                foreach (var item in listaproductos)
                {
                    var apiResponse = await _productoService.ObtenerStock<StockDTO>(item.ArticuloId, ubicacion);

                    item.StockActual = apiResponse.isExitoso ? apiResponse.Resultado?.Cantidad ?? 0 : 0;
                }                
            }

            var resultServicio = await _servicioService.ObtenerTodos<List<ServicioDTO>>();
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
