using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_API.Modelos.DTO;
using SistemaFacturacion_API.Modelos;
using SistemaFacturacion_API.Repositorio;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductoRepositorio _ProductoRepositorio;
        protected APIResponse _response;

        public ProductoController(ILogger<ProductoController> logger, IProductoRepositorio productoRepositorio, IMapper mapper)
        {
            _logger = logger;
            _ProductoRepositorio = productoRepositorio;
            _mapper = mapper;
            _response = new APIResponse();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetProductos()
        {
            //_logger.LogInformation("Obteniendo datos de las Productos");
            try
            {
                IEnumerable<Producto> ProductoList = await _ProductoRepositorio.ObtenerTodos(incluirPropiedades: "TipoImpuesto,Marca,Presentacion,TipoProducto");
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
        public async Task<ActionResult<APIResponse>> GetProductosById(int id)
        {
            _logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");

            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var producto = await _ProductoRepositorio.Obtener(p => p.Articulonro == id, tracked: false, incluirPropiedades: "TipoImpuesto,Marca,Presentacion,TipoProducto");

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
        public async Task<ActionResult<APIResponse>> CrearProducto([FromBody] ProductoCreateDTO CreateDTO)
        {
            try
            {
                if (_ProductoRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower()) == null)
                {
                    var mensajeError = "El producto con el mismo nombre ingresado ya existe";
                    ModelState.AddModelError("ErrorMessages", mensajeError);
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string>() { mensajeError };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var _producto = _mapper.Map<Producto>(CreateDTO);
                _producto.Fecharegistro = DateTime.Now;


                await _ProductoRepositorio.Crear(_producto);

                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _producto;


                return CreatedAtRoute("GetProductosById", new { id = _producto.Articulonro }, _response);
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
        public async Task<IActionResult> UpdateProducto(int id, [FromBody] ProductoUpdateDTO productoUpdatedto)
        {
            try
            {
                if (productoUpdatedto == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var producto = await _ProductoRepositorio.Obtener(c => c.Articulonro == id, tracked: false);
                if (producto == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                Producto modelo = _mapper.Map<Producto>(productoUpdatedto);
                modelo.Articulonro = id;
                modelo.Fechaultactualizacion = DateTime.Now;

                await _ProductoRepositorio.Actualizar(modelo);

                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }

            return BadRequest(_response);
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EliminarProducto(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var marca = await _ProductoRepositorio.Obtener(c => c.Articulonro == id, tracked: false);
                if (marca == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _ProductoRepositorio.Eliminar(marca);

                _response.isExitoso = true;
                _response.Resultado = marca;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }

            return BadRequest(_response);

        }



    }
}
