using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaFacturacion_Web.Models.DTO;
using SistemaFacturacion_Web.Services.IServices;
using SistemaWeb_Aplicacion.Models;

namespace SistemaFacturacion_Web.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarcaService _marcaService;
        private readonly IMapper _mapper;
        public MarcaController(IMarcaService marcaService, IMapper mapper)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexMarca()
        {
            List<MarcaDTO> marcaList = new();
            var response = await _marcaService.ObtenerTodos<APIResponse>();

            if (response!= null && response.isExitoso)
            {
                marcaList = JsonConvert.DeserializeObject<List<MarcaDTO>>(Convert.ToString(response.Resultado));
            }


            return View(marcaList);
        }


        //Get
        public async Task<IActionResult> CrearMarca()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearMarca(MarcaCreateDTO modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _marcaService.Crear<APIResponse>(modelo);
                    if (response != null && response.isExitoso)
                    {
                        TempData["Exitoso"] = "Se ha registrado la marca exitosamente";
                        return RedirectToAction(nameof(IndexMarca));
                    }

                    TempData["Error"] = $"No se pudo insertar la Marca: {response.ErrorMessages[0]}";
                }
                
                return View(modelo);// Otra opción podría ser devolver BadRequest en caso de error
            }
            catch (Exception ex)
            {
                // Agrega un mensaje de depuración
                Console.WriteLine($"Error en CrearMarca: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        public async Task<IActionResult> ActualizarMarca(int marcaId) 
        {
            var response = await _marcaService.Obtener<APIResponse>(marcaId);

            if (response != null && response.isExitoso)
            {
                MarcaDTO modelo = JsonConvert.DeserializeObject<MarcaDTO>(response.Resultado.ToString());
                return View(modelo);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarMarca(MarcaDTO modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _marcaService.Actualizar<APIResponse>(modelo);

                if (response != null && response.isExitoso)
                {
                    TempData["Exitoso"] = "La Marca se ha actualizado con éxito";
                    return RedirectToAction(nameof(IndexMarca));
                }  
            }

            return View(modelo);          
        }



        public async Task<IActionResult> EliminarMarca(int marcaId)
        {
            var response = await _marcaService.Obtener<APIResponse>(marcaId);

            if (response != null && response.isExitoso)
            {
                MarcaDTO modelo = JsonConvert.DeserializeObject<MarcaDTO>(response.Resultado.ToString());
                return View(modelo);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarMarca(MarcaDTO modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _marcaService.Eliminar<APIResponse>(modelo.Marcanro);

                if (response != null && response.isExitoso)
                {
                    TempData["Exitoso"] = "La marca se ha eliminado con éxito";
                    return RedirectToAction(nameof(IndexMarca));
                }
            }

            return View(modelo);
        }





    }
}
