using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_API.Datos;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_API.Repositorio;


namespace SistemaFacturacion_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]    
    public class CiudadController : ControllerBase
    {
        private readonly ILogger<CiudadController> _logger;
        private readonly IMapper _mapper;
        private readonly ICiudadRepositorio _ciudadRepositorio;

        public CiudadController(ILogger<CiudadController> logger, ICiudadRepositorio ciudadRepositorio, IMapper mapper)
        {
            _logger = logger;
            _ciudadRepositorio = ciudadRepositorio;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<CiudadDTO>>>> GetCiudad()
        {      
            var _response = new APIResponse<IEnumerable<CiudadDTO>>();
            try
            {
                //_logger.LogInformation("Obteniendo lista de Ciudads");
                IEnumerable<Ciudad> CiudadList = await _ciudadRepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<CiudadDTO>>(CiudadList);
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


        [HttpGet("{id:int}", Name = "GetCiudadById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse<CiudadDTO>>> GetCiudadById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            var _response = new APIResponse<CiudadDTO>();
            try
            {
                if (id == 0) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                    

                var ciudad = await _ciudadRepositorio.Obtener(p => p.CiudadId == id);

                if (ciudad == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<CiudadDTO>(ciudad);
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
        public async Task<ActionResult<APIResponse<CiudadDTO>>> CrearCiudad([FromBody] CiudadCreateDTO CreateDTO)
        {
            var _response = new APIResponse<CiudadDTO>();
            try
            {
                var existeCiudad = _ciudadRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower());
                if (existeCiudad.Result != null)
                {
                    ModelState.AddModelError("ErrorMessages", "La Ciudad con el nombre ingresado ya existe");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var _ciudad = new Ciudad();
                _ciudad.Descripcion = CreateDTO.Descripcion;

                await _ciudadRepositorio.Crear(_ciudad);
                await _ciudadRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<CiudadDTO>(_ciudad);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetCiudadById", new { id = _ciudad.CiudadId }, _response);
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
        public async Task<ActionResult<APIResponse<object>>> ActualizarCiudad(short id,[FromBody] CiudadCreateDTO CreateDTO)
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

                var ciudad = await _ciudadRepositorio.Obtener(c => c.CiudadId == id, tracked: false);
                if (ciudad == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                Ciudad modelo = _mapper.Map<Ciudad>(CreateDTO);
                modelo.CiudadId = id;

                await _ciudadRepositorio.Actualizar(modelo);
                await _ciudadRepositorio.Grabar();

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
        public async Task<ActionResult<APIResponse<object>>> EliminarCiudad(int id)
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

                var ciudad = await _ciudadRepositorio.Obtener(c => c.CiudadId == id, tracked: false);
                if (ciudad == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _ciudadRepositorio.Eliminar(ciudad);
                await _ciudadRepositorio.Grabar();

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
