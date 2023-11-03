using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacionWeb.Datos;
using SistemaFacturacionWeb.Modelos;
using SistemaFacturacionWeb.Modelos.DTO;

namespace SistemaFacturacionWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _db;

        public VillaController(ILogger<VillaController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.LogInformation("Obteniendo datos de las villas");
            return Ok(_db.Villas.ToList());
        }


        [HttpGet("id:int", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            //var villa = VillaStore.VillaList.Where(c => c.Id == id).FirstOrDefault();
            var villa = _db.Villas.Where(c => c.Id == id).FirstOrDefault();

            if (villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CrearVilla([FromBody] VillaDTO villa)
        {
            try
            {
                if (_db.Villas.Where(v => v.Nombre.ToLower() == villa.Nombre.ToLower()).Count() > 0)
                {
                    ModelState.AddModelError("NombreExiste", "La villa con el nombre ingresado ya existe");
                    return BadRequest(ModelState);
                }

                if (villa == null)
                {
                    return BadRequest();
                }

                if (villa.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                Villa nuevaVilla = new Villa()
                {
                    Nombre = villa.Nombre,
                    Detalle = villa.Detalle,
                    MetrosCuadratos = villa.MetrosCuadratos,
                    Amenidad = villa.Amenidad,
                    ImagenURL = villa.ImagenURL,
                    FechaCreacion = DateTime.Now,
                    Ocupantes = villa.Ocupantes,
                    Tarifa = villa.Tarifa
                };

                _db.Villas.Add(nuevaVilla);
                _db.SaveChanges();

                return CreatedAtRoute("GetVilla", new { id = nuevaVilla.Id }, nuevaVilla);
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
        public IActionResult DeleteVila(int id) 
        {
            if (id==0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.Where(c => c.Id == id).FirstOrDefault();
            if (villa == null)
            {
                return NotFound();
            }

            _db.Villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villadto) 
        {
            if (villadto == null || id != villadto.Id )
            {
                return BadRequest();
            }

            var villa = _db.Villas.Where(c => c.Id == id).FirstOrDefault();
            if (villa == null)
            {
                return NotFound();
            }

            Villa modelo = new Villa()
            {
                Nombre = villa.Nombre,
                Detalle = villa.Detalle,
                MetrosCuadratos = villa.MetrosCuadratos,
                Amenidad = villa.Amenidad,
                ImagenURL = villa.ImagenURL,
                FechaCreacion = DateTime.Now,
                Ocupantes = villa.Ocupantes,
                Tarifa = villa.Tarifa
            };

            _db.Villas.Update(modelo);
            _db.SaveChanges();

            return NoContent();
        }



        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVilla(int id, JsonPatchDocument<VillaDTO> patchDto)
        {
            if (patchDto == null)
            {
                return BadRequest();
            }

            var villa = _db.Villas.AsNoTracking().FirstOrDefault(v => v.Id == id);

            VillaDTO villadto = new()
            {
                Nombre = villa.Nombre,
                Detalle = villa.Detalle,
                MetrosCuadratos = villa.MetrosCuadratos,
                Amenidad = villa.Amenidad,
                ImagenURL = villa.ImagenURL,
                Ocupantes = villa.Ocupantes,
                Tarifa = villa.Tarifa
            };


            if (villa== null)
            {
                return BadRequest();
            }

            patchDto.ApplyTo(villadto, ModelState);

            Villa modelo = new Villa()
            {
                Nombre = villa.Nombre,
                Detalle = villa.Detalle,
                MetrosCuadratos = villa.MetrosCuadratos,
                Amenidad = villa.Amenidad,
                ImagenURL = villa.ImagenURL,
                FechaCreacion = DateTime.Now,
                Ocupantes = villa.Ocupantes,
                Tarifa = villa.Tarifa
            };



            _db.Villas.Update(modelo);
            _db.SaveChanges();

            return NoContent();
        }


    }
}
