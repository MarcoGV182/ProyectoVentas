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
    [Authorize]
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductoRepositorio _ProductoRepositorio;
        private readonly IStockRepositorio _StockRepositorio;
        private readonly IUbicacionRepositorio _UbicacionRepositorio;

        public ProductoController(ILogger<ProductoController> logger, IProductoRepositorio productoRepositorio, IStockRepositorio StockRepositorio, IMapper mapper, IUbicacionRepositorio ubicacionRepositorio)
        {
            _logger = logger;
            _ProductoRepositorio = productoRepositorio;
            _StockRepositorio = StockRepositorio;
            _mapper = mapper;
            _UbicacionRepositorio = ubicacionRepositorio;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<ProductoDTO>>>> GetProductos()
        {
            //_logger.LogInformation("Obteniendo datos de las Productos");
            var _response = new APIResponse<IEnumerable<ProductoDTO>>();
            try
            {
                IEnumerable<Producto> ProductoList = await _ProductoRepositorio.ObtenerTodos(incluirPropiedades: "TipoImpuesto,Marca,Presentacion,Categoria,UnidadMedida");
                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _mapper.Map<IEnumerable<ProductoDTO>>(ProductoList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }

            return _response;
            
        }

        [HttpGet("Producto-por-ubicacion/{ubicacionid:int}", Name = "GetProductosByUbicacion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<ProductoDTO>>>> GetProductosByUbicacion(int ubicacionid)
        {
            //_logger.LogInformation("Obteniendo datos de las Productos");
            var _response = new APIResponse<IEnumerable<ProductoDTO>>();
            try
            {
                IEnumerable<Producto> ProductoList = await _ProductoRepositorio.ObtenerTodos(c=>c.Stocks.Any(s=>s.UbicacionId == ubicacionid),incluirPropiedades: "TipoImpuesto,Marca,Presentacion,Categoria,UnidadMedida,Stocks");
                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _mapper.Map<IEnumerable<ProductoDTO>>(ProductoList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }

            return _response;

        }


        [HttpGet("{id:int}", Name = "GetProductosById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse<ProductoDTO>>> GetProductosById(int id)
        {
            _logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            var _response = new APIResponse<ProductoDTO>();
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var producto = await _ProductoRepositorio.Obtener(p => p.ArticuloId == id, tracked: false, incluirPropiedades: "TipoImpuesto,Marca,Presentacion,Categoria,UnidadMedida");

                if (producto == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _mapper.Map<ProductoDTO>(producto);

               
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse<Producto>>> CrearProducto([FromBody] ProductoCreateDTO CreateDTO)
        {
            var _response = new APIResponse<Producto>();
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                if (_ProductoRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower()) == null)
                {
                    var mensajeError = "El producto con el mismo nombre ingresado ya existe";
                    ModelState.AddModelError("ErrorMessages", mensajeError);
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string>() { mensajeError };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                if (!CreateDTO.Stocks.Any())
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "No existe ubicaciones para registrar el Stock del Producto" };
                    return BadRequest(_response);
                }

                // -- Validar ubicacion
                foreach (var item in CreateDTO.Stocks)
                {
                    var ExisteActiva = await _UbicacionRepositorio.ValidarUbicacionActiva(item.UbicacionId);
                    if (!ExisteActiva)
                    {
                        _response.isExitoso = false;
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.ErrorMessages = new List<string>() { $"Ubicación {item.UbicacionId} no encontrada o inactiva" };
                        return BadRequest(_response);
                    }
                }


                // -- Crear articulo
                var _producto = _mapper.Map<Producto>(CreateDTO);
                _producto.Fecharegistro = DateTime.Now;

                // --Guardar cambios
                await _ProductoRepositorio.Crear(_producto);
                await _ProductoRepositorio.Grabar();

                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _producto;


                return CreatedAtRoute("GetProductosById", new { id = _producto.ArticuloId }, _response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;

        }



        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse<Producto>>> UpdateProducto(int id, [FromBody] ProductoUpdateDTO productoUpdatedto)
        {
            var _response = new APIResponse<Producto>();
            try
            {
                if (productoUpdatedto == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var producto = await _ProductoRepositorio.Obtener(c => c.ArticuloId == id, tracked: false);
                if (producto == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                Producto modelo = _mapper.Map<Producto>(productoUpdatedto);
                modelo.ArticuloId = id;
                modelo.Fechaultactualizacion = DateTime.Now;

                await _ProductoRepositorio.Actualizar(modelo);
                await _ProductoRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = modelo;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
                return BadRequest(_response);
            }
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse<object>>> EliminarProducto(int id)
        {
            var _response = new APIResponse<IEnumerable<ProductoDTO>>();
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var producto = await _ProductoRepositorio.Obtener(c => c.ArticuloId == id, tracked: false);
                if (producto == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _ProductoRepositorio.Eliminar(producto);
                await _ProductoRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = null;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string> { ex.Message };
                return BadRequest(_response);
            }
        }
    }
}
