using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionWeb.Modelos.DTO;
using SistemaFacturacionWeb.Modelos;
using SistemaFacturacionWeb.Repositorio.IRepositorio;

namespace SistemaFacturacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas()
        {
            //_logger.LogInformation("Obteniendo datos de las Productos");

            IEnumerable<Marca> MarcaList = await _marcaRepositorio.ObtenerTodos();

            return Ok(_mapper.Map<IEnumerable<Marca>>(MarcaList));
        }


        [HttpGet("id:int", Name = "GetMarcaById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcaById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            try
            {
                if (id == 0)
                    return BadRequest();

                var marca = await _marcaRepositorio.Obtener(p => p.Marcanro == id, includes: "Productos");

                if (marca == null)
                    return NoContent();

                return Ok(marca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Marca>> CrearMarca([FromBody] MarcaCreateDTO CreateDTO)
        {
            try
            {
                if (_marcaRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower()) == null)
                {
                    ModelState.AddModelError("NombreExiste", "La Marca con el nombre ingresado ya existe");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    return BadRequest();
                }

                var _marca = new Marca();
                _marca.Descripcion = CreateDTO.Descripcion;

                await _marcaRepositorio.Crear(_marca);

                return CreatedAtRoute("GetMarcaById", new { id = _marca.Marcanro }, _marca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}
