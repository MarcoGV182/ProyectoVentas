using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacionWeb.Modelos.DTO;
using SistemaFacturacionWeb.Modelos;
using SistemaFacturacionWeb.Repositorio;
using SistemaFacturacionWeb.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace SistemaFacturacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductoRepositorio _ProductoRepositorio;

        public ProductoController(ILogger<ProductoController> logger, IProductoRepositorio productoRepositorio, IMapper mapper)
        {
            _logger = logger;
            _ProductoRepositorio = productoRepositorio;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductos()
        {
            _logger.LogInformation("Obteniendo datos de las Productos");

            IEnumerable<Producto> ProductoList = await _ProductoRepositorio.ObtenerTodos(includes: "TipoImpuesto");

            return Ok(_mapper.Map<IEnumerable<ProductoDTO>>(ProductoList));
        }


        [HttpGet("id:int", Name = "GetProductosById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<ProductoDTO>>> GetProductosById(int id)
        {
            _logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");

            if (id == 0)
                return BadRequest();

            var producto = await _ProductoRepositorio.Obtener(p=>p.Articulonro == id,includes: "TipoImpuesto");

            if (producto == null)
                return NoContent();

            return Ok(_mapper.Map<ProductoDTO>(producto));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductoDTO>> CrearProducto([FromBody] ProductoCreateDTO CreateDTO)
        {
            try
            {
                if (_ProductoRepositorio.Obtener(v => v.Descripcion.ToLower() == CreateDTO.Descripcion.ToLower()) == null)
                {
                    ModelState.AddModelError("NombreExiste", "El producto con el nombre ingresado ya existe");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    return BadRequest();
                }

                var _producto = _mapper.Map<Producto>(CreateDTO);
                _producto.Fecharegistro = DateTime.Now;
                _producto.Tipoarticulo = TipoArticulo.Producto;

                await _ProductoRepositorio.Crear(_producto);

                return CreatedAtRoute("GetProductosById", new { id = _producto.Articulonro }, _ProductoRepositorio);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }



        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProducto(int id, [FromBody] ProductoUpdateDTO productoUpdatedto)
        {
            if (productoUpdatedto == null || id != productoUpdatedto.Articulonro)
            {
                return BadRequest();
            }

            var producto = await _ProductoRepositorio.Obtener(c => c.Articulonro == id,tracked:false);
            if (producto == null)
            {
                return NotFound();
            }

            Producto modelo = _mapper.Map<Producto>(productoUpdatedto);
            modelo.Fechaultactualizacion = DateTime.Now;

            await _ProductoRepositorio.Actualizar(modelo);

            return NoContent();
        }



    }
}
