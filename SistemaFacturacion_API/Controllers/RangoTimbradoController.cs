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
    [Authorize(Roles = "Admin")]
    public class RangoTimbradoController : ControllerBase
    {
        private readonly ILogger<RangoTimbradoController> _logger;
        private readonly IMapper _mapper;
        private readonly IRangoTimbradoRepositorio _RangoTimbradoRepositorio;
        private readonly ITimbradoRepositorio _timbradoRepositorio;

        public RangoTimbradoController(ILogger<RangoTimbradoController> logger, IRangoTimbradoRepositorio RangoTimbradoRepositorio, IMapper mapper, ITimbradoRepositorio timbradoRepositorio)
        {
            _logger = logger;
            _RangoTimbradoRepositorio = RangoTimbradoRepositorio;
            _mapper = mapper;
            _timbradoRepositorio = timbradoRepositorio;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<RangoTimbradoDTO>>>> GetRangoTimbrados()
        {     
            var _response = new APIResponse<IEnumerable<RangoTimbradoDTO>>();
            try
            {
                //_logger.LogInformation("Obteniendo lista de Timbrados");
                IEnumerable<Rango_Timbrados> TimbradoList = await _RangoTimbradoRepositorio.ObtenerTodos(incluirPropiedades:"Timbrado,Sucursal");

                _response.Resultado = _mapper.Map<IEnumerable<RangoTimbradoDTO>>(TimbradoList);
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


        [HttpGet("{id:int}", Name = "GetRangoTimbradoyId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse<RangoTimbradoDTO>>> GetRangoTimbradoyId(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            var _response = new APIResponse<RangoTimbradoDTO>();
            try
            {
                if (id == 0) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                
                var Rango = await _RangoTimbradoRepositorio.Obtener(p => p.Id == id, incluirPropiedades: "Timbrado,Sucursal");

                if (Rango == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<RangoTimbradoDTO>(Rango);
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
        public async Task<ActionResult<APIResponse<RangoTimbradoDTO>>> Crear([FromBody] RangoTimbradoCreateDTO CreateDTO)
        {
            var _response = new APIResponse<RangoTimbradoDTO>();
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string>() { "Faltan algunos datos" };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var existeTimbrado = await _timbradoRepositorio.Obtener(v => v.TimbradoId == CreateDTO.TimbradoId);
                if (existeTimbrado == null)
                {
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string>() { "El timbrado no existe" };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }



                var _Timbrado = _mapper.Map<Rango_Timbrados>(CreateDTO);
                await _RangoTimbradoRepositorio.Crear(_Timbrado);
                await _RangoTimbradoRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<RangoTimbradoDTO>(_Timbrado); 
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetRangoTimbradoyId", new { id = _Timbrado.TimbradoId }, _response);
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
        public async Task<ActionResult<APIResponse<object>>> Actualizar(short id,[FromBody] RangoTimbradoCreateDTO CreateDTO)
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

                var RangoTimbrado = await _RangoTimbradoRepositorio.Obtener(c => c.Id == id, tracked: false);
                if (RangoTimbrado == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                var existeTimbrado = await _timbradoRepositorio.Obtener(v => v.TimbradoId == CreateDTO.TimbradoId);
                if (existeTimbrado == null)
                {
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string>() { "El timbrado no existe" };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                Rango_Timbrados modelo = _mapper.Map<Rango_Timbrados>(CreateDTO);
                modelo.TimbradoId = id;

                await _RangoTimbradoRepositorio.Actualizar(modelo);
                await _RangoTimbradoRepositorio.Grabar();

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
        public async Task<ActionResult<APIResponse<object>>> Eliminar(int id)
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

                var Timbrado = await _RangoTimbradoRepositorio.Obtener(c => c.TimbradoId == id, tracked: false);
                if (Timbrado == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _RangoTimbradoRepositorio.Eliminar(Timbrado);
                await _RangoTimbradoRepositorio.Grabar();

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
