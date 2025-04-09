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

        public TipoDocumentoIdentidadController(ILogger<TipoDocumentoIdentidadController> logger, ITipoDocumentoIdentidadRepositorio TipoDocumentoRepositorio, IMapper mapper)
        {
            _logger = logger;
            _TipoDocumentoIdentidadRepositorio = TipoDocumentoRepositorio;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<TablaMenorDTO>>>> GetTipoDocumentoIdentidad()
        {       
            var _response = new APIResponse<IEnumerable<TablaMenorDTO>>();
            try
            {
                //_logger.LogInformation("Obteniendo lista de TipoDocumentoIdentidads");
                IEnumerable<TipoDocumentoIdentidad> TipoDocumentoIdentidadList = await _TipoDocumentoIdentidadRepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<TablaMenorDTO>>(TipoDocumentoIdentidadList);
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
        public async Task<ActionResult<APIResponse<TablaMenorDTO>>> GetTipoDocumentoIdentidadById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            var _response = new APIResponse<TablaMenorDTO>();
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
                _response.Resultado =  _mapper.Map<TablaMenorDTO>(TipoDocumentoIdentidad);
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
        public async Task<ActionResult<APIResponse<TablaMenorDTO>>> CrearTipoDocumentoIdentidad([FromBody] TablaMenorCreateDTO CreateDTO)
        {
            var _response = new APIResponse<TablaMenorDTO>();
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var existeTipoDocumentoIdentidad = await _TipoDocumentoIdentidadRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower());
                if (existeTipoDocumentoIdentidad != null)
                {
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string>() { "El registro con el nombre ingresado ya existe" };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                

                var _TipoDocumentoIdentidad = new TipoDocumentoIdentidad();
                _TipoDocumentoIdentidad.Descripcion = CreateDTO.Descripcion;

                await _TipoDocumentoIdentidadRepositorio.Crear(_TipoDocumentoIdentidad);
                await _TipoDocumentoIdentidadRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<TablaMenorDTO>(_TipoDocumentoIdentidad);
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
        public async Task<ActionResult<APIResponse<object>>> ActualizarTipoDocumentoIdentidad(int id,[FromBody] TablaMenorCreateDTO CreateDTO)
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
                await _TipoDocumentoIdentidadRepositorio.Grabar();

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
        public async Task<ActionResult<APIResponse<object>>> EliminarTipoDocumentoIdentidad(int id)
        {
            var _response = new APIResponse<object>();
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
                await _TipoDocumentoIdentidadRepositorio.Grabar();

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
