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
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServicioController : ControllerBase
    {
        private readonly ILogger<ServicioController> _logger;
        private readonly IMapper _mapper;
        private readonly IServicioRepositorio _ServicioRepositorio;

        public ServicioController(ILogger<ServicioController> logger, IServicioRepositorio ServicioRepositorio, IMapper mapper)
        {
            _logger = logger;
            _ServicioRepositorio = ServicioRepositorio;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<ServicioDTO>>>> GetServicios()
        {
            var _response = new APIResponse<IEnumerable<ServicioDTO>>();
            try
            {
                //_logger.LogInformation("Obteniendo lista de Servicios");
                IEnumerable<Servicio> ServicioList = await _ServicioRepositorio.ObtenerTodos(incluirPropiedades: "TipoImpuesto,TipoServicio");

                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _mapper.Map<IEnumerable<ServicioDTO>>(ServicioList);
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


        [HttpGet("{id:int}", Name = "GetServicioById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse<ServicioDTO>>> GetServicioById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            var _response = new APIResponse<ServicioDTO>();
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var Servicio = await _ServicioRepositorio.Obtener(p => p.ArticuloId == id, incluirPropiedades: "TipoImpuesto,TipoServicio");

                if (Servicio == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.StatusCode = HttpStatusCode.OK;
                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<ServicioDTO>(Servicio);
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
        public async Task<ActionResult<APIResponse<ServicioDTO>>> CrearServicio([FromBody] ServicioCreateDTO CreateDTO)
        {
            var _response = new APIResponse<ServicioDTO>();
            try
            {
                var existeServicio = _ServicioRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower());
                if (existeServicio.Result != null)
                {
                    ModelState.AddModelError("ErrorMessages", "La Servicio con el nombre ingresado ya existe");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var _Servicio = _mapper.Map<Servicio>(CreateDTO);
                _Servicio.Fecharegistro = DateTime.Now;

                await _ServicioRepositorio.Crear(_Servicio);
                await _ServicioRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<ServicioDTO>(_Servicio);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetServicioById", new { id = _Servicio.ArticuloId }, _response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
                return BadRequest(ex);
            }

        }



        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse<object>>> ActualizarServicio(int id, [FromBody] ServicioCreateDTO CreateDTO)
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

                var Servicio = await _ServicioRepositorio.Obtener(c => c.ArticuloId == id, tracked: false);
                if (Servicio == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                Servicio modelo = _mapper.Map<Servicio>(CreateDTO);
                modelo.ArticuloId = id;

                await _ServicioRepositorio.Actualizar(modelo);
                await _ServicioRepositorio.Grabar();

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
            }

            return BadRequest(_response);

        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse<ServicioDTO>>> EliminarServicio(int id)
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

                var Servicio = await _ServicioRepositorio.Obtener(c => c.ArticuloId == id, tracked: false);
                if (Servicio == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _ServicioRepositorio.Eliminar(Servicio);
                await _ServicioRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = Servicio;
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
