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
using Microsoft.AspNetCore.Http.HttpResults;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TimbradoController : ControllerBase
    {
        private readonly ILogger<TimbradoController> _logger;
        private readonly IMapper _mapper;
        private readonly ITimbradoRepositorio _TimbradoRepositorio;

        public TimbradoController(ILogger<TimbradoController> logger, ITimbradoRepositorio TimbradoRepositorio, IMapper mapper)
        {
            _logger = logger;
            _TimbradoRepositorio = TimbradoRepositorio;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<TimbradoDTO>>>> GetTimbrados()
        {     
            var _response = new APIResponse<IEnumerable<TimbradoDTO>>();
            try
            {
                //_logger.LogInformation("Obteniendo lista de Timbrados");
                IEnumerable<Timbrado> TimbradoList = await _TimbradoRepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<TimbradoDTO>>(TimbradoList);
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


        [HttpGet("{id:int}", Name = "GetTimbradoById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse<TimbradoDTO>>> GetTimbradoById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            var _response = new APIResponse<TimbradoDTO>();
            try
            {
                if (id == 0) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                    

                var Timbrado = await _TimbradoRepositorio.Obtener(p => p.TimbradoId == id);

                if (Timbrado == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<TimbradoDTO>(Timbrado);
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
        public async Task<ActionResult<APIResponse<TimbradoDTO>>> CrearTimbrado([FromBody] TimbradoCreateDTO CreateDTO)
        {
            var _response = new APIResponse<TimbradoDTO>();
            try
            {
                var existeTimbrado = _TimbradoRepositorio.Obtener(v => v.Numero.ToLower() == CreateDTO.Numero.ToLower() && v.FechaInicioVigencia == CreateDTO.FechaInicioVigencia);
                if (existeTimbrado.Result != null)
                {
                    ModelState.AddModelError("ErrorMessages", "El Timbrado con el nro y fecha de inicio de vigencia ya existe");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var _Timbrado = _mapper.Map<Timbrado>(CreateDTO);
                _Timbrado.Estado = "A";
                await _TimbradoRepositorio.Crear(_Timbrado);
                await _TimbradoRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<TimbradoDTO>(_Timbrado); 
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetTimbradoById", new { id = _Timbrado.TimbradoId }, _response);
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
        public async Task<ActionResult<APIResponse<object>>> ActualizarTimbrado(short id,[FromBody] TimbradoCreateDTO CreateDTO)
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

                var Timbrado = await _TimbradoRepositorio.Obtener(c => c.TimbradoId == id, tracked: false);
                if (Timbrado == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                Timbrado modelo = _mapper.Map<Timbrado>(CreateDTO);
                modelo.TimbradoId = id;

                await _TimbradoRepositorio.Actualizar(modelo);
                await _TimbradoRepositorio.Grabar();

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
        public async Task<ActionResult<APIResponse<TimbradoDTO>>> EliminarTimbrado(int id)
        {
            var _response = new APIResponse<TimbradoDTO>();
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var Timbrado = await _TimbradoRepositorio.Obtener(c => c.TimbradoId == id, tracked: false);
                if (Timbrado == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _TimbradoRepositorio.Eliminar(Timbrado);
                await _TimbradoRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<TimbradoDTO>(Timbrado); ;
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
