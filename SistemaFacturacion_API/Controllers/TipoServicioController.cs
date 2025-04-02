using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_API.Repositorio;
using Microsoft.AspNetCore.Http.HttpResults;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoServicioController : ControllerBase
    {
        private readonly ILogger<TipoServicioController> _logger;
        private readonly IMapper _mapper;
        private readonly ITipoServicioRepositorio _TipoServicioRepositorio;

        public TipoServicioController(ILogger<TipoServicioController> logger, ITipoServicioRepositorio TipoServicioRepositorio, IMapper mapper)
        {
            _logger = logger;
            _TipoServicioRepositorio = TipoServicioRepositorio;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<TipoServicioDTO>>>> GetTipoServicio()
        {
            var _response = new APIResponse<IEnumerable<TipoServicioDTO>>();
            try
            {
                //_logger.LogInformation("Obteniendo lista de TipoServicios");
                IEnumerable<TipoServicio> TipoServicioList = await _TipoServicioRepositorio.ObtenerTodos();

                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _mapper.Map<IEnumerable<TipoServicioDTO>>(TipoServicioList);
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
        public async Task<ActionResult<APIResponse<TipoServicioDTO>>> GetTipoServicioById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            var _response = new APIResponse<TipoServicioDTO>();
            try
            {
                if (id == 0) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                    

                var TipoServicio = await _TipoServicioRepositorio.Obtener(p => p.TipoServicioId == id);

                if (TipoServicio == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<TipoServicioDTO>(TipoServicio);
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
        public async Task<ActionResult<APIResponse<TipoServicioDTO>>> CrearTipoServicio([FromBody] TablaMenorCreateDTO CreateDTO)
        {
           var _response = new APIResponse<TipoServicioDTO>();
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
                await _TipoServicioRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<TipoServicioDTO>(_TipoServicio); 
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetTipoServicioById", new { id = _TipoServicio.TipoServicioId }, _response);
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
        public async Task<ActionResult<APIResponse<object>>> ActualizarTipoServicio(int id,[FromBody] TablaMenorCreateDTO CreateDTO)
        {
            var _response = new APIResponse<object>();
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var TipoServicio = await _TipoServicioRepositorio.Obtener(c => c.TipoServicioId == id, tracked: false);
                if (TipoServicio == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                TipoServicio modelo = _mapper.Map<TipoServicio>(CreateDTO);
                modelo.TipoServicioId = (short)id;

                await _TipoServicioRepositorio.Actualizar(modelo);
                await _TipoServicioRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = null;
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
        public async Task<ActionResult<APIResponse<object>>> EliminarTipoServicio(int id)
        {
            var _response = new APIResponse<object>();
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var TipoServicio = await _TipoServicioRepositorio.Obtener(c => c.TipoServicioId == id, tracked: false);
                if (TipoServicio == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _TipoServicioRepositorio.Eliminar(TipoServicio);
                await _TipoServicioRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = null;
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
