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
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly IMapper _mapper;
        private readonly ICategoriaProductoRepositorio _CategoriaRepositorio;

        public CategoriaController(ILogger<CategoriaController> logger, ICategoriaProductoRepositorio CategoriaRepositorio, IMapper mapper)
        {
            _logger = logger;
            _CategoriaRepositorio = CategoriaRepositorio;
            _mapper = mapper;
            
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<CategoriaProductoDTO>>>> GetCategoria()
        {
            var _response = new APIResponse<IEnumerable<CategoriaProductoDTO>>();
            try
            {
                //_logger.LogInformation("Obteniendo lista de Categorias");
                IEnumerable<CategoriaProducto> CategoriaList = await _CategoriaRepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<CategoriaProductoDTO>>(CategoriaList);
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


        [HttpGet("{id:int}", Name = "GetCategoriaById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse<CategoriaProductoDTO>>> GetCategoriaById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            var _response = new APIResponse<CategoriaProductoDTO>();
            try
            {
                if (id == 0) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                    

                var Categoria = await _CategoriaRepositorio.Obtener(p => p.CategoriaId == id);

                if (Categoria == null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }
                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<CategoriaProductoDTO>(Categoria);
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
        public async Task<ActionResult<APIResponse<CategoriaProductoDTO>>> CrearCategoria([FromBody] CategoriaProductoCreateDTO CreateDTO)
        {
            var _response = new APIResponse<CategoriaProductoDTO>();
            try
            {
                if (!ModelState.IsValid)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = ModelState.GetErrorMessages();
                    return BadRequest(_response);
                }

                var existeCategoria = _CategoriaRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower());
                if (existeCategoria.Result != null)
                {   
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "El Tipo de Producto con el nombre ingresado ya existe" };
                    return BadRequest(_response);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var _Categoria = new CategoriaProducto();
                _Categoria.Descripcion = CreateDTO.Descripcion;

                await _CategoriaRepositorio.Crear(_Categoria);
                await _CategoriaRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<CategoriaProductoDTO>(_Categoria);
                _response.StatusCode = HttpStatusCode.Created;

                return CreatedAtRoute("GetCategoriaById", new { id = _Categoria.CategoriaId }, _response);
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
        public async Task<ActionResult<APIResponse<CategoriaProductoDTO>>> ActualizarCategoria(int id,[FromBody] CategoriaProductoCreateDTO CreateDTO)
        {
            var _response = new APIResponse<CategoriaProductoDTO>();
            try
            {
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var Categoria = await _CategoriaRepositorio.Obtener(c => c.CategoriaId == id, tracked: false);
                if (Categoria == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                var modelo = _mapper.Map<CategoriaProducto>(CreateDTO);
                modelo.CategoriaId = (short)id;

                await _CategoriaRepositorio.Actualizar(modelo);
                await _CategoriaRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<CategoriaProductoDTO>(modelo);
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
        public async Task<ActionResult<APIResponse<CategoriaProductoDTO>>> EliminarCategoria(int id)
        {
            var _response = new APIResponse<CategoriaProductoDTO>();
            try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var Categoria = await _CategoriaRepositorio.Obtener(c => c.CategoriaId == id, tracked: false);
                if (Categoria == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                await _CategoriaRepositorio.Eliminar(Categoria);
                await _CategoriaRepositorio.Grabar();

                _response.isExitoso = true;
                _response.Resultado = _mapper.Map<CategoriaProductoDTO>(Categoria);
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
