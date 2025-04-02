using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_API.Repositorio;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class StockController : Controller
    {
        private readonly ILogger<StockController> _logger;
        private readonly IMapper _mapper;
        private readonly IStockRepositorio _stockRepositorio;
        private readonly IProductoRepositorio _productoRepositorio;
        private readonly IUbicacionRepositorio _ubicacionRepositorio;

        public StockController(ILogger<StockController> logger, 
                               IStockRepositorio StockRepositorio,  
                               IProductoRepositorio productoRepositorio,
                               IUbicacionRepositorio ubicacionRepositorio,
                               IMapper mapper)
        {
            _logger = logger;
            _stockRepositorio = StockRepositorio;
            _productoRepositorio = productoRepositorio;
            _ubicacionRepositorio = ubicacionRepositorio;
            _mapper = mapper;           
        }



        [HttpPost("AgregarStock")]
        public async Task<ActionResult<APIResponse<object>>> AgregarStock([FromBody] StockAddDTO request)
        {
            var _response = new APIResponse<object>();
            _response.isExitoso = true;

            // Validaciones básicas
            var producto = await _productoRepositorio.Obtener(c=>c.ArticuloId == request.ProductoId);
            if (producto == null || !producto.Estado.Equals("A"))
            {
                _response.Resultado = null;
                _response.ErrorMessages = new List<string> { "Producto no encontrado o inactivo" };
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound("Producto no encontrado o inactivo");
            }
              

            var ubicacion = await _ubicacionRepositorio.Obtener(c=> c.UbicacionId == request.UbicacionId);
            if (ubicacion == null || !ubicacion.Activa) 
            {
                _response.Resultado = null;
                _response.ErrorMessages = new List<string> { "Ubicación no encontrada o inactiva" };
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound("Producto no encontrado o inactivo");

            }                

            if (request.Cantidad <= 0) 
            {
                _response.Resultado = null;
                _response.ErrorMessages = new List<string> { "La cantidad debe ser mayor a cero" };
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound("Producto no encontrado o inactivo");
            }


            await _stockRepositorio.AgregarStockAsync(
                request.ProductoId,
                request.UbicacionId,
                request.Cantidad);

            return Ok(_response);
        }



        [HttpGet("ProductosDisponibles/{ubicacionId}")]
        public async Task<ActionResult<APIResponse<IEnumerable<ProductoDTO>>>> ObtenerProductosDisponibles(int ubicacionId)
        {
            var _response = new APIResponse<IEnumerable<ProductoDTO>>();
            try
            {
                _response.isExitoso = true;

                var ubicacion = await _ubicacionRepositorio.Obtener(c => c.UbicacionId == ubicacionId);
                if (ubicacion == null || !ubicacion.Activa) 
                {
                    _response.Resultado = null;
                    _response.ErrorMessages = new List<string> { "Ubicación no encontrada o inactiva" };
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);

                }
                    
                var productos = await _stockRepositorio.ObtenerProductosDisponiblesAsync(ubicacionId);
                _response.Resultado = _mapper.Map<IEnumerable<ProductoDTO>>(productos);               
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };               
            }

            return Ok(_response);

        }



        [HttpGet("ObtenerCantidadDisponible")]
        public async Task<ActionResult<APIResponse<StockDTO>>> ObtenerCantidadDisponible(int productoId,int ubicacionId)
        {
            var _response = new APIResponse<StockDTO>();
            StockDTO _stock = new StockDTO();
            try
            {
                var cantidad = await _stockRepositorio.ObtenerCantidadDisponibleAsync(productoId, ubicacionId);
                _stock.Cantidad = cantidad;
                _stock.ProductoId = productoId;
                _stock.UbicacionId = ubicacionId;


                _response.isExitoso = true;
                _response.Resultado = _stock;                
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
                _response.Resultado = null;
            }

            return Ok(_response);
        }
    }
}
