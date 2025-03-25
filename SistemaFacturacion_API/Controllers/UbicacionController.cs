using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_API.Repositorio;
using Microsoft.AspNetCore.Http.HttpResults;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UbicacionController : ControllerBase
    {
        private readonly ILogger<UbicacionController> _logger;
        private readonly IMapper _mapper;
        private readonly IUbicacionRepositorio _UbicacionRepositorio;
        protected APIResponse _response;

        public UbicacionController(ILogger<UbicacionController> logger, IUbicacionRepositorio UbicacionRepositorio, IMapper mapper)
        {
            _logger = logger;
            _UbicacionRepositorio = UbicacionRepositorio;
            _mapper = mapper;
            _response = new APIResponse();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetUbicacion()
        {            
            try
            {
                //_logger.LogInformation("Obteniendo lista de Ubicacions");
                IEnumerable<Ubicacion> UbicacionList = await _UbicacionRepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<Ubicacion>>(UbicacionList);
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


        [HttpGet("{id:int}", Name = "GetUbicacionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> GetUbicacionById(int id)
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
                    

                var Ubicacion = await _UbicacionRepositorio.Obtener(p => p.UbicacionId == id);

                if (Ubicacion == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.isExitoso = true;
                _response.Resultado = Ubicacion;
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
        public async Task<ActionResult<APIResponse>> CrearUbicacion([FromBody] UbicacionCreateDTO CreateDTO)
        {
            try
            {
                var existeUbicacion = _UbicacionRepositorio.Obtener(v => v.Nombre.ToLower() == CreateDTO.Nombre.ToLower() &&
                                                                         v.Direccion.ToLower() == CreateDTO.Direccion.ToLower());
                if (existeUbicacion.Result != null)
                {
                    ModelState.AddModelError("ErrorMessages", "La registro con el mismo Nombre y dirección ya existe");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var _Ubicacion = _mapper.Map<Ubicacion>(CreateDTO);

                await _UbicacionRepositorio.Crear(_Ubicacion);
                await _UbicacionRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _Ubicacion;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetUbicacionById", new { id = _Ubicacion.UbicacionId }, _response);
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
        public async Task<ActionResult<APIResponse>> ActualizarUbicacion(int id,[FromBody] UbicacionCreateDTO CreateDTO)
        {
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var Ubicacion = await _UbicacionRepositorio.Obtener(c => c.UbicacionId == id, tracked: false);
                if (Ubicacion == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                Ubicacion modelo = _mapper.Map<Ubicacion>(CreateDTO);
                modelo.UbicacionId = (short)id;

                await _UbicacionRepositorio.Actualizar(modelo);
                await _UbicacionRepositorio.Grabar();

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
        public async Task<ActionResult<APIResponse>> EliminarUbicacion(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var Ubicacion = await _UbicacionRepositorio.Obtener(c => c.UbicacionId == id, tracked: false);
                if (Ubicacion == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _UbicacionRepositorio.Eliminar(Ubicacion);
                await _UbicacionRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = Ubicacion;
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
