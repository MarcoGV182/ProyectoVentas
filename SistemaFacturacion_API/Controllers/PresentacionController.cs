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
    public class PresentacionController : ControllerBase
    {
        private readonly ILogger<PresentacionController> _logger;
        private readonly IMapper _mapper;
        private readonly IPresentacionRepositorio _PresentacionRepositorio;
        protected APIResponse _response;

        public PresentacionController(ILogger<PresentacionController> logger, IPresentacionRepositorio PresentacionRepositorio, IMapper mapper)
        {
            _logger = logger;
            _PresentacionRepositorio = PresentacionRepositorio;
            _mapper = mapper;
            _response = new APIResponse();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetPresentacion()
        {            
            try
            {
                //_logger.LogInformation("Obteniendo lista de Presentacions");
                IEnumerable<Presentacion> PresentacionList = await _PresentacionRepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<Presentacion>>(PresentacionList);
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


        [HttpGet("{id:int}", Name = "GetPresentacionById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> GetPresentacionById(int id)
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
                    

                var Presentacion = await _PresentacionRepositorio.Obtener(p => p.PresentacionId == id);

                if (Presentacion == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.isExitoso = true;
                _response.Resultado = Presentacion;
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
        public async Task<ActionResult<APIResponse>> CrearPresentacion([FromBody] PresentacionCreateDTO CreateDTO)
        {
            try
            {
                var existePresentacion = _PresentacionRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower());
                if (existePresentacion.Result != null)
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

                var _Presentacion = new Presentacion();
                _Presentacion.Descripcion = CreateDTO.Descripcion;

                await _PresentacionRepositorio.Crear(_Presentacion);
                await _PresentacionRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _Presentacion;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetPresentacionById", new { id = _Presentacion.PresentacionId }, _response);
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
        public async Task<ActionResult<APIResponse>> ActualizarPresentacion(int id,[FromBody] PresentacionCreateDTO CreateDTO)
        {
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var Presentacion = await _PresentacionRepositorio.Obtener(c => c.PresentacionId == id, tracked: false);
                if (Presentacion == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                Presentacion modelo = _mapper.Map<Presentacion>(CreateDTO);
                modelo.PresentacionId = (short)id;

                await _PresentacionRepositorio.Actualizar(modelo);
                await _PresentacionRepositorio.Grabar();

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
        public async Task<ActionResult<APIResponse>> EliminarPresentacion(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var Presentacion = await _PresentacionRepositorio.Obtener(c => c.PresentacionId == id, tracked: false);
                if (Presentacion == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _PresentacionRepositorio.Eliminar(Presentacion);
                await _PresentacionRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = Presentacion;
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
