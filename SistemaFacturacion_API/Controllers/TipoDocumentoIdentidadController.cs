using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_API.Datos;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_API.Repositorio;
using Microsoft.AspNetCore.Http.HttpResults;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TipoDocumentoIdentidadController : ControllerBase
    {
        private readonly ILogger<TipoDocumentoIdentidadController> _logger;
        private readonly IMapper _mapper;
        private readonly ITipoDocumentoIdentidadRepositorio _TipoDocumentoIdentidadRepositorio;
        protected APIResponse _response;

        public TipoDocumentoIdentidadController(ILogger<TipoDocumentoIdentidadController> logger, ITipoDocumentoIdentidadRepositorio TipoDocumentoRepositorio, IMapper mapper)
        {
            _logger = logger;
            _TipoDocumentoIdentidadRepositorio = TipoDocumentoRepositorio;
            _mapper = mapper;
            _response = new APIResponse();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetTipoDocumentoIdentidad()
        {            
            try
            {
                //_logger.LogInformation("Obteniendo lista de TipoDocumentoIdentidads");
                IEnumerable<TipoDocumentoIdentidad> TipoDocumentoIdentidadList = await _TipoDocumentoIdentidadRepositorio.ObtenerTodos();

                _response.Resultado = TipoDocumentoIdentidadList;
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


        [HttpGet("{id:int}", Name = "GetTipoDocumentoIdentidadById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> GetTipoDocumentoIdentidadById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            try
            {
                if (id == 0) 
                {
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string>() { "Registro no existe" };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                    

                var TipoDocumentoIdentidad = await _TipoDocumentoIdentidadRepositorio.Obtener(p => p.Id == id);

                if (TipoDocumentoIdentidad == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.isExitoso = true;
                _response.Resultado = TipoDocumentoIdentidad;
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
        public async Task<ActionResult<APIResponse>> CrearTipoDocumentoIdentidad([FromBody] TablaMenorCreateDTO CreateDTO)
        {
            try
            {
                var existeTipoDocumentoIdentidad = _TipoDocumentoIdentidadRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower());
                if (existeTipoDocumentoIdentidad.Result != null)
                {
                    ModelState.AddModelError("ErrorMessages", "El registro con el nombre ingresado ya existe");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var _TipoDocumentoIdentidad = new TipoDocumentoIdentidad();
                _TipoDocumentoIdentidad.Descripcion = CreateDTO.Descripcion;

                await _TipoDocumentoIdentidadRepositorio.Crear(_TipoDocumentoIdentidad);

                _response.isExitoso = true;
                _response.Resultado = _TipoDocumentoIdentidad;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetTipoDocumentoIdentidadById", new { id = _TipoDocumentoIdentidad.Id }, _response);
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
        public async Task<ActionResult<APIResponse>> ActualizarTipoDocumentoIdentidad(int id,[FromBody] TablaMenorCreateDTO CreateDTO)
        {
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var TipoDocumentoIdentidad = await _TipoDocumentoIdentidadRepositorio.Obtener(c => c.Id == id, tracked: false);
                if (TipoDocumentoIdentidad == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                TipoDocumentoIdentidad modelo = _mapper.Map<TipoDocumentoIdentidad>(CreateDTO);
                modelo.Id = (short)id;

                await _TipoDocumentoIdentidadRepositorio.Actualizar(modelo);               

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
        public async Task<ActionResult<APIResponse>> EliminarTipoDocumentoIdentidad(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string> { "Registro no existe" };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var TipoDocumentoIdentidad = await _TipoDocumentoIdentidadRepositorio.Obtener(c => c.Id == id, tracked: false);
                if (TipoDocumentoIdentidad == null)
                {
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string> { "Registro no existe" };
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _TipoDocumentoIdentidadRepositorio.Eliminar(TipoDocumentoIdentidad);

                _response.isExitoso = true;
                _response.Resultado = TipoDocumentoIdentidad;
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
