using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacionWeb.Datos;
using SistemaFacturacionWeb.Modelos;
using SistemaFacturacionWeb.Modelos.DTO;
using SistemaFacturacionWeb.Repositorio.IRepositorio;

namespace SistemaFacturacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;     
        private readonly IMapper _mapper;
        private readonly IVillaRepositorio _villaRepositorio;

        public VillaController(ILogger<VillaController> logger, IVillaRepositorio villaRepositorio, IMapper mapper)
        {
            _logger = logger;
            _villaRepositorio = villaRepositorio;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            _logger.LogInformation("Obteniendo datos de las villas");

            IEnumerable<Villa> villaList = await _villaRepositorio.ObtenerTodos();

            return Ok(_mapper.Map<IEnumerable<VillaDTO>>(villaList));
        }


        [HttpGet("id:int", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VillaDTO>> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            //var villa = VillaStore.VillaList.Where(c => c.Id == id).FirstOrDefault();
            var villa = await _villaRepositorio.Obtener(c => c.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            var retorno = _mapper.Map<VillaDTO>(villa);

            return Ok(retorno);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDTO>> CrearVilla([FromBody] VillaCreateDTO CreateDTO)
        {
            try
            {
                if (_villaRepositorio.Obtener(v => v.Nombre.ToLower() == CreateDTO.Nombre.ToLower()) == null)
                {
                    ModelState.AddModelError("NombreExiste", "La villa con el nombre ingresado ya existe");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    return BadRequest();
                }
                               
                var Modelo = _mapper.Map<Villa>(CreateDTO);

                await _villaRepositorio.Crear(Modelo);

                return CreatedAtRoute("GetVilla", new { id = Modelo.Id }, Modelo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           

            

        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVila(int id) 
        {
            if (id==0)
            {
                return BadRequest();
            }

            var villa = await _villaRepositorio.Obtener(c => c.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            await _villaRepositorio.Eliminar(villa);

            return NoContent();
        
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaUpdateDTO villaUpdatedto) 
        {
            if (villaUpdatedto == null || id != villaUpdatedto.Id )
            {
                return BadRequest();
            }

            var villa = await _villaRepositorio.Obtener(c => c.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            Villa modelo = _mapper.Map<Villa>(villaUpdatedto);

            await _villaRepositorio.Actualizar(villa);

            return NoContent();
        }



        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDto)
        {
            if (patchDto == null)
            {
                return BadRequest();
            }

            var villa = await _villaRepositorio.Obtener(c => c.Id == id,false);

            VillaUpdateDTO villadto = _mapper.Map<VillaUpdateDTO>(villa);


            if (villa== null)
            {
                return BadRequest();
            }

            patchDto.ApplyTo(villadto, ModelState);

            Villa modelo = _mapper.Map<Villa>(villadto);

            await _villaRepositorio.Eliminar(villa);

            return NoContent();
        }


    }
}
