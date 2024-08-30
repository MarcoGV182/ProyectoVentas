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
    public class TipoServicioController : ControllerBase
    {
        private readonly ILogger<TipoServicioController> _logger;
        private readonly IMapper _mapper;
        private readonly ITipoServicioRepositorio _TipoServicioRepositorio;
        protected APIResponse _response;

        public TipoServicioController(ILogger<TipoServicioController> logger, ITipoServicioRepositorio TipoServicioRepositorio, IMapper mapper)
        {
            _logger = logger;
            _TipoServicioRepositorio = TipoServicioRepositorio;
            _mapper = mapper;
            _response = new APIResponse();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetTipoServicio()
        {            
            try
            {
                //_logger.LogInformation("Obteniendo lista de TipoServicios");
                IEnumerable<TipoServicio> TipoServicioList = await _TipoServicioRepositorio.ObtenerTodos();

                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _mapper.Map<IEnumerable<TipoServicio>>(TipoServicioList);
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


        [HttpGet("{id:int}", Name = "GetTipoServicioById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> GetTipoServicioById(int id)
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
                    

                var TipoServicio = await _TipoServicioRepositorio.Obtener(p => p.TipoServicoNro == id);

                if (TipoServicio == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.isExitoso = true;
                _response.Resultado = TipoServicio;
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
        public async Task<ActionResult<APIResponse>> CrearTipoServicio([FromBody] TipoServicioCreateDTO CreateDTO)
        {
            try
            {
                var existeTipoServicio = _TipoServicioRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower());
                if (existeTipoServicio.Result != null)
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

                var _TipoServicio = new TipoServicio();
                _TipoServicio.Descripcion = CreateDTO.Descripcion;

                await _TipoServicioRepositorio.Crear(_TipoServicio);

                _response.isExitoso = true;
                _response.Resultado = _TipoServicio;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetTipoServicioById", new { id = _TipoServicio.TipoServicoNro }, _response);
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
        public async Task<ActionResult<APIResponse>> ActualizarTipoServicio(int id,[FromBody] TipoServicioCreateDTO CreateDTO)
        {
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var TipoServicio = await _TipoServicioRepositorio.Obtener(c => c.TipoServicoNro == id, tracked: false);
                if (TipoServicio == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                TipoServicio modelo = _mapper.Map<TipoServicio>(CreateDTO);
                modelo.TipoServicoNro = (short)id;

                await _TipoServicioRepositorio.Actualizar(modelo);               

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
                return BadRequest(_response);
            }
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> EliminarTipoServicio(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var TipoServicio = await _TipoServicioRepositorio.Obtener(c => c.TipoServicoNro == id, tracked: false);
                if (TipoServicio == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _TipoServicioRepositorio.Eliminar(TipoServicio);

                _response.isExitoso = true;
                _response.Resultado = TipoServicio;
                _response.StatusCode = HttpStatusCode.NoContent;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string> { ex.Message, ex.InnerException.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
