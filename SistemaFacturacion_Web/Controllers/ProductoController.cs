using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SistemaFacturacion_Web.Models.DTO;
using SistemaFacturacion_Web.Models.ViewModel;
using SistemaFacturacion_Web.Services;
using SistemaFacturacion_Web.Services.IServices;
using SistemaWeb_Aplicacion.Models;
using System.Reflection;

namespace SistemaFacturacion_Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoService _productoService;
        private readonly IMarcaService _marcaService;
        private readonly ITipoImpuestoService _tipoImpuestoService;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService productoService, IMarcaService marcaService, ITipoImpuestoService tipoImpuestoService, IMapper mapper)
        {
            _productoService = productoService;
            _marcaService = marcaService;
            _tipoImpuestoService = tipoImpuestoService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexProducto()
        {
            List<ProductoDTO> productoList = new();
            var response = await _productoService.ObtenerTodos<APIResponse>();

            if (response != null && response.isExitoso)
            {
                productoList = JsonConvert.DeserializeObject<List<ProductoDTO>>(Convert.ToString(response.Resultado));
            }

            return View(productoList);
        }


        //Get
        public async Task<IActionResult> CrearProducto()
        {
            ProductoCreateViewModel datosProd = new ProductoCreateViewModel();
            var responseMarca = await _marcaService.ObtenerTodos<APIResponse>();
            if (responseMarca != null && responseMarca.isExitoso)
            {
                datosProd.MarcaLista = JsonConvert.DeserializeObject<List<MarcaDTO>>(responseMarca.Resultado.ToString()).Select(v => new SelectListItem
                {
                    Text = v.Descripcion,
                    Value = v.Marcanro.ToString()

                });
            }

            var responseTI = await _tipoImpuestoService.ObtenerTodos<APIResponse>();
            if (responseTI != null && responseTI.isExitoso)
            {
                datosProd.TipoImpuestoLista = JsonConvert.DeserializeObject<List<TipoImpuestoDTO>>(responseTI.Resultado.ToString()).Select(v => new SelectListItem
                {
                    Text = v.Descripcion,
                    Value = v.TipoimpuestoNro.ToString()

                });
            }

            return View(datosProd);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearProducto(ProductoCreateViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _productoService.Crear<APIResponse>(modelo.Producto);
                if (response != null && response.isExitoso)
                {
                    return RedirectToAction(nameof(IndexProducto));
                }
                else
                {
                    if (response.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", response.ErrorMessages.FirstOrDefault());
                    }
                }
            

                response = await _marcaService.ObtenerTodos<APIResponse>();
                if (response != null && response.isExitoso)
                {
                    modelo.MarcaLista = JsonConvert.DeserializeObject<List<MarcaDTO>>(response.Resultado.ToString()).Select(v => new SelectListItem
                    {
                        Text = v.Descripcion,
                        Value = v.Marcanro.ToString()

                    });
                }

                var res = await _tipoImpuestoService.ObtenerTodos<APIResponse>();
                if (res != null && res.isExitoso)
                {
                    modelo.TipoImpuestoLista = JsonConvert.DeserializeObject<List<TipoImpuestoDTO>>(res.Resultado.ToString()).Select(v => new SelectListItem
                    {
                        Text = v.Descripcion,
                        Value = v.TipoimpuestoNro.ToString()
                    });
                }

            }

            return View(modelo);
        }


        public async Task<IActionResult> ActualizarProducto(int productoId)
        {
            ProductoUpdateViewModel productoVM = new();

            var response = await _productoService.Obtener<APIResponse>(productoId);

            if (response != null && response.isExitoso)
            {
                ProductoDTO modelo = JsonConvert.DeserializeObject<ProductoDTO>(response.Resultado.ToString());
                productoVM.Producto = _mapper.Map<ProductoUpdateDTO>(modelo);
            }

            response = await _marcaService.ObtenerTodos<APIResponse>();
            if (response != null && response.isExitoso)
            {
                productoVM.MarcaLista = JsonConvert.DeserializeObject<List<MarcaDTO>>(response.Resultado.ToString()).Select(v => new SelectListItem
                {
                    Text = v.Descripcion,
                    Value = v.Marcanro.ToString()

                });
            }

            response = await _tipoImpuestoService.ObtenerTodos<APIResponse>();
            if (response != null && response.isExitoso)
            {
                productoVM.TipoImpuestoLista = JsonConvert.DeserializeObject<List<TipoImpuestoDTO>>(response.Resultado.ToString()).Select(v => new SelectListItem
                {
                    Text = v.Descripcion,
                    Value = v.TipoimpuestoNro.ToString()
                });
            }

            return View(productoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActualizarProducto(ProductoUpdateViewModel modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _productoService.Actualizar<APIResponse>(modelo.Producto);

                if (response != null && response.isExitoso)
                {
                    TempData["Exitoso"] = "El Producto se ha actualizado con éxito";
                    return RedirectToAction(nameof(IndexProducto));
                }
                else
                {
                    TempData["Error"] = $"El producto no fue actualizado: {response.ErrorMessages[0]}";
                }
            }

            return View(modelo);
        }



        public async Task<IActionResult> EliminarProducto(int productoId)
        {
            var response = await _productoService.Obtener<APIResponse>(productoId);

            if (response != null && response.isExitoso)
            {
                ProductoDTO modelo = JsonConvert.DeserializeObject<ProductoDTO>(response.Resultado.ToString());
                return View(modelo);
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarProducto(ProductoDTO modelo)
        {
            if (ModelState.IsValid)
            {
                var response = await _productoService.Eliminar<APIResponse>(modelo.Articulonro);

                if (response != null && response.isExitoso)
                {
                    TempData["Exitoso"] = "La marca se ha eliminado con éxito";
                    return RedirectToAction(nameof(IndexProducto));
                }
            }

            return View(modelo);
        }
    }
}
