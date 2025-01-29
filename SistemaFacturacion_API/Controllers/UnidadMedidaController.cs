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
    public class UnidadMedidaController : ControllerBase
    {
        private readonly ILogger<UnidadMedidaController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnidadMedidaRepositorio _UnidadMedidaRepositorio;
        protected APIResponse _response;

        public UnidadMedidaController(ILogger<UnidadMedidaController> logger, IUnidadMedidaRepositorio UnidadMedidaRepositorio, IMapper mapper)
        {
            _logger = logger;
            _UnidadMedidaRepositorio = UnidadMedidaRepositorio;
            _mapper = mapper;
            _response = new APIResponse();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetUnidadMedidas()
        {            
            try
            {
                //_logger.LogInformation("Obteniendo lista de UnidadMedidas");
                IEnumerable<UnidadMedida> UnidadMedidaList = await _UnidadMedidaRepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<UnidadMedidaDTO>>(UnidadMedidaList);
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


        [HttpGet("{id:int}", Name = "GetUnidadMedidaById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> GetUnidadMedidaById(int id)
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
                    

                var UnidadMedida = await _UnidadMedidaRepositorio.Obtener(p => p.UnidadMedidaId == id);

                if (UnidadMedida == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                _response.Resultado = _mapper.Map<UnidadMedidaDTO>(UnidadMedida);
                _response.isExitoso = true;
                _response.Resultado = UnidadMedida;
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
        public async Task<ActionResult<APIResponse>> CrearUnidadMedida([FromBody] UnidadMedidaCreateDTO CreateDTO)
        {
            try
            {
                var existeUnidadMedida = _UnidadMedidaRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower());
                if (existeUnidadMedida.Result != null)
                {
                    ModelState.AddModelError("ErrorMessages", "La UnidadMedida con el nombre ingresado ya existe");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var _UnidadMedida = new UnidadMedida();
                _UnidadMedida.Descripcion = CreateDTO.Descripcion;

                await _UnidadMedidaRepositorio.Crear(_UnidadMedida);

                _response.isExitoso = true;
                _response.Resultado = _UnidadMedida;
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetUnidadMedidaById", new { id = _UnidadMedida.UnidadMedidaId }, _response);
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
        public async Task<ActionResult<APIResponse>> ActualizarUnidadMedida(int id,[FromBody] UnidadMedidaCreateDTO CreateDTO)
        {
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var UnidadMedida = await _UnidadMedidaRepositorio.Obtener(c => c.UnidadMedidaId == id, tracked: false);
                if (UnidadMedida == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                UnidadMedida modelo = _mapper.Map<UnidadMedida>(CreateDTO);
                modelo.UnidadMedidaId = (short)id;

                await _UnidadMedidaRepositorio.Actualizar(modelo);               

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
            }

            return BadRequest(_response);

        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> EliminarUnidadMedida(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var UnidadMedida = await _UnidadMedidaRepositorio.Obtener(c => c.UnidadMedidaId == id, tracked: false);
                if (UnidadMedida == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _UnidadMedidaRepositorio.Eliminar(UnidadMedida);

                _response.isExitoso = true;
                _response.Resultado = UnidadMedida;
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
