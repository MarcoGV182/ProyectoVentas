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
    //[Authorize
    public class MarcaController : ControllerBase
    {
        private readonly ILogger<MarcaController> _logger;
        private readonly IMapper _mapper;
        private readonly IMarcaRepositorio _marcaRepositorio;

        public MarcaController(ILogger<MarcaController> logger, IMarcaRepositorio marcaRepositorio, IMapper mapper)
        {
            _logger = logger;
            _marcaRepositorio = marcaRepositorio;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<MarcaDTO>>>> GetMarcas()
        {          
            var _response = new APIResponse<IEnumerable<MarcaDTO>>();
            try
            {
                //_logger.LogInformation("Obteniendo lista de Marcas");
                IEnumerable<Marca> MarcaList = await _marcaRepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<MarcaDTO>>(MarcaList);
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


        [HttpGet("{id:int}", Name = "GetMarcaById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse<MarcaDTO>>> GetMarcaById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            var _response = new APIResponse<MarcaDTO>();
            try
            {
                if (id == 0) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                    

                var marca = await _marcaRepositorio.Obtener(p => p.MarcaId == id);

                if (marca == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<MarcaDTO>(marca);
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
        public async Task<ActionResult<APIResponse<MarcaDTO>>> CrearMarca([FromBody] MarcaCreateDTO CreateDTO)
        {
            var _response = new APIResponse<MarcaDTO>();
            try
            {
                var existeMarca = _marcaRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower());
                if (existeMarca.Result != null)
                {
                    ModelState.AddModelError("ErrorMessages", "La Marca con el nombre ingresado ya existe");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var _marca = new Marca();
                _marca.Descripcion = CreateDTO.Descripcion;

                await _marcaRepositorio.Crear(_marca);
                await _marcaRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<MarcaDTO>(_marca);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetMarcaById", new { id = _marca.MarcaId }, _response);
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
        public async Task<ActionResult<APIResponse<MarcaDTO>>> ActualizarMarca(int id,[FromBody] MarcaCreateDTO CreateDTO)
        {
            var _response = new APIResponse<MarcaDTO>();
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var marca = await _marcaRepositorio.Obtener(c => c.MarcaId == id, tracked: false);
                if (marca == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                Marca modelo = _mapper.Map<Marca>(CreateDTO);
                modelo.MarcaId = id;

                await _marcaRepositorio.Actualizar(modelo);
                await _marcaRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<MarcaDTO>(modelo);
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
        public async Task<ActionResult<APIResponse<object>>> EliminarMarca(int id)
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

                var marca = await _marcaRepositorio.Obtener(c => c.MarcaId == id, tracked: false);
                if (marca == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _marcaRepositorio.Eliminar(marca);
                await _marcaRepositorio.Grabar();

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
