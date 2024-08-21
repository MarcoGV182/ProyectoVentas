using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_API.Modelos.DTO;
using SistemaFacturacion_API.Modelos;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_API.Repositorio;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TipoProductoController : ControllerBase
    {
        private readonly ILogger<TipoProductoController> _logger;
        private readonly IMapper _mapper;
        private readonly ITipoProductoRepositorio _TipoProductoRepositorio;
        protected APIResponse _response;

        public TipoProductoController(ILogger<TipoProductoController> logger, ITipoProductoRepositorio TipoProductoRepositorio, IMapper mapper)
        {
            _logger = logger;
            _TipoProductoRepositorio = TipoProductoRepositorio;
            _mapper = mapper;
            _response = new APIResponse();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetTipoProducto()
        {            
            try
            {
                //_logger.LogInformation("Obteniendo lista de TipoProductos");
                IEnumerable<TipoProducto> TipoProductoList = await _TipoProductoRepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<TipoProducto>>(TipoProductoList);
                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };                
            }
            return _response;
        }


        [HttpGet("{id:int}", Name = "GetTipoProductoById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> GetTipoProductoById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            try
            {
                if (id == 0) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                    

                var TipoProducto = await _TipoProductoRepositorio.Obtener(p => p.TipoProductonro == id);

                if (TipoProducto == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.isExitoso = true;
                _response.Resultado = TipoProducto;
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message.ToString() };
            }

            return _response;

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CrearTipoProducto([FromBody] TipoProductoCreateDTO CreateDTO)
        {
            try
            {
                var existeTipoProducto = _TipoProductoRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower());
                if (existeTipoProducto.Result != null)
                {
                    ModelState.AddModelError("ErrorMessages", "El Tipo de Producto con el nombre ingresado ya existe");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var _TipoProducto = new TipoProducto();
                _TipoProducto.Descripcion = CreateDTO.Descripcion;

                await _TipoProductoRepositorio.Crear(_TipoProducto);

                _response.isExitoso = true;
                _response.Resultado = _TipoProducto;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetTipoProductoById", new { id = _TipoProducto.TipoProductonro }, _response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message};
                return BadRequest(ex);
            }

        }



        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ActualizarTipoProducto(int id,[FromBody] TipoProductoCreateDTO CreateDTO)
        {
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var TipoProducto = await _TipoProductoRepositorio.Obtener(c => c.TipoProductonro == id, tracked: false);
                if (TipoProducto == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                TipoProducto modelo = _mapper.Map<TipoProducto>(CreateDTO);
                modelo.TipoProductonro = (short)id;

                await _TipoProductoRepositorio.Actualizar(modelo);               

                _response.isExitoso = true;
                _response.Resultado = modelo;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.Message };
                _response.StatusCode = HttpStatusCode.BadRequest;            
            }

            return BadRequest(_response);

        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> EliminarTipoProducto(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var TipoProducto = await _TipoProductoRepositorio.Obtener(c => c.TipoProductonro == id, tracked: false);
                if (TipoProducto == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _TipoProductoRepositorio.Eliminar(TipoProducto);

                _response.isExitoso = true;
                _response.Resultado = TipoProducto;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string> { ex.Message, ex.InnerException.ToString() };
            }

            return BadRequest(_response);

        }

    }
}
