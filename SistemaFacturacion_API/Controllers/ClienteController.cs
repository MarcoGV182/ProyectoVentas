using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_API.Repositorio;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_Utilidad;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IMapper _mapper;
        private readonly IClienteRepositorio _ClienteRepositorio;

        public ClienteController(ILogger<ClienteController> logger, IClienteRepositorio ClienteRepositorio, IMapper mapper)
        {
            _logger = logger;
            _ClienteRepositorio = ClienteRepositorio;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<ClienteDTO>>>> GetClientes()
        {         
            var _response = new APIResponse<IEnumerable<ClienteDTO>>();
            try
            {
                //_logger.LogInformation("Obteniendo lista de Clientes");
                IEnumerable<Persona> ClienteList = await _ClienteRepositorio.ObtenerTodos(incluirPropiedades: "Ciudad,TipoDocumentoIdentidad,Colaborador");

                _response.Resultado = _mapper.Map<IEnumerable<ClienteDTO>>(ClienteList);
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


        [HttpGet("{id:int}", Name = "GetClienteById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse<ClienteDTO>>> GetClienteById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            var _response = new APIResponse<ClienteDTO>();
            try
            {
                if (id == 0) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }                    

                var Cliente = await _ClienteRepositorio.Obtener(p => p.PersonaId == id,incluirPropiedades: "Ciudad,TipoDocumentoIdentidad,Colaborador");

                if (Cliente == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<ClienteDTO>(Cliente);
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
        public async Task<ActionResult<APIResponse<ClienteDTO>>> CrearCliente([FromBody] ClienteCreateDTO CreateDTO)
        {
            var _response = new APIResponse<ClienteDTO>();
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ModelState.GetErrorMessages();
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var existeCliente = await _ClienteRepositorio.Obtener(v => v.Nrodocumento.ToLower() == CreateDTO.Nrodocumento.ToLower());
                if (existeCliente != null)
                {   
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "El Cliente con el mismo numero de documento ingresado ya existe" };
                    return BadRequest(existeCliente);
                }
                
                Persona modelo = _mapper.Map<Persona>(CreateDTO);
                await _ClienteRepositorio.Crear(modelo);
                await _ClienteRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<ClienteDTO>(modelo);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetClienteById", new { id = modelo.PersonaId }, _response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message};
                return BadRequest(_response);
            }

        }



        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse<object>>> ActualizarCliente(int id,[FromBody] ClienteCreateDTO CreateDTO)
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

                var Cliente = await _ClienteRepositorio.Obtener(c => c.PersonaId == id, tracked: false);
                if (Cliente == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                Persona modelo = _mapper.Map<Persona>(CreateDTO);
                modelo.PersonaId = id;

                await _ClienteRepositorio.Actualizar(modelo);
                await _ClienteRepositorio.Grabar();

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
        public async Task<ActionResult<APIResponse<object>>> EliminarCliente(int id)
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

                var Cliente = await _ClienteRepositorio.Obtener(c => c.PersonaId == id, tracked: false);
                if (Cliente == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _ClienteRepositorio.Eliminar(Cliente);
                await _ClienteRepositorio.Grabar();

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
