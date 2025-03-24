using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoImpuestoController : ControllerBase
    {
        private readonly ILogger<TipoImpuestoController> _logger;
        private readonly IMapper _mapper;
        private readonly ITipoImpuestoRepositorio _tipoImpuestoRepositorio;
        protected APIResponse _response;

        public TipoImpuestoController(ILogger<TipoImpuestoController> logger, IMapper mapper, ITipoImpuestoRepositorio TIRepositorio)
        {
            _logger = logger;
            _mapper = mapper;
            _tipoImpuestoRepositorio = TIRepositorio;
            _response = new APIResponse();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> ObtenerTipoImpuesto()
        {
            try
            {
                //_logger.LogInformation("Obteniendo lista de Marcas");
                IEnumerable<TipoImpuesto> TipoImpuestoList = await _tipoImpuestoRepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<TipoImpuestoDTO>>(TipoImpuestoList);
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


        [HttpGet("{id:int}", Name = "ObtenerTipoImpuestoById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> ObtenerTipoImpuestoById(int id)
        {
            _logger.LogInformation($"Obteniendo datos de los Tipos de Impuesto por id: {id}");

            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var tipoImpuesto = await _tipoImpuestoRepositorio.Obtener(p => p.TipoimpuestoId == id);

                if (tipoImpuesto == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _mapper.Map<TipoImpuestoDTO>(tipoImpuesto);

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


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CrearTipoImpuesto([FromBody] TipoImpuestoCreateDTO CreateDTO)
        {
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var existeImpuesto = _tipoImpuestoRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower());
                if (existeImpuesto.Result != null)
                {
                    ModelState.AddModelError("ErrorMessages", "El Tipo de Impuesto con el nombre ingresado ya existe");
                    return BadRequest(ModelState);
                }



                TipoImpuesto _tipoImpuesto = _mapper.Map<TipoImpuesto>(CreateDTO);

                await _tipoImpuestoRepositorio.Crear(_tipoImpuesto);
                await _tipoImpuestoRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _tipoImpuesto;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("ObtenerTipoImpuestoById", new { id = _tipoImpuesto.TipoimpuestoId }, _response);
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
        public async Task<ActionResult<APIResponse>> ActualizarTipoImpuesto(short id, [FromBody] TipoImpuestoCreateDTO UpdateDTO)
        {
            try
            {
                if (UpdateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var marca = await _tipoImpuestoRepositorio.Obtener(c => c.TipoimpuestoId == id, tracked: false);
                if (marca == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                TipoImpuesto modelo = _mapper.Map<TipoImpuesto>(UpdateDTO);
                modelo.TipoimpuestoId = id;

                await _tipoImpuestoRepositorio.Actualizar(modelo);
                await _tipoImpuestoRepositorio.Grabar();

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
        public async Task<ActionResult<APIResponse>> EliminarTipoImpuesto(int id)
        {
            try
            {
                #region Validaciones
                //Validar que el id recibido no sea cero
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                //Validar que el objecto a eliminar exista
                var tipoImpuesto = await _tipoImpuestoRepositorio.Obtener(c => c.TipoimpuestoId == id, tracked: false);

                if (tipoImpuesto == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                #endregion

                await _tipoImpuestoRepositorio.Eliminar(tipoImpuesto);
                await _tipoImpuestoRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = tipoImpuesto;
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
