using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_API.Repositorio;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_API.Migrations;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : Controller
    {
        private readonly ILogger<VentaController> _logger;
        private readonly IMapper _mapper;
        private readonly IVentaRepositorio _VentaRepositorio;
        private readonly IStockRepositorio _stockRepositorio;
        private readonly ApplicationDbContext _context;

        public VentaController(ILogger<VentaController> logger, IVentaRepositorio ventaRepositorio, IMapper mapper, IStockRepositorio stockRepositorio, ApplicationDbContext context)
        {
            _logger = logger;
            _VentaRepositorio = ventaRepositorio;
            _mapper = mapper;     
            _stockRepositorio = stockRepositorio;
            _context = context;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<VentaDTO>>>> GetVentas()
        {
            //_logger.LogInformation("Obteniendo datos de las Ventas");
            var _response = new APIResponse<IEnumerable<VentaDTO>>();
            try
            {
                IEnumerable<Venta> VentaList = await _VentaRepositorio.ObtenerTodos(incluirPropiedades: "TipoImpuesto,Cliente,Vendedor,Timbrado,Empresa,DetalleVenta");
                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _mapper.Map<IEnumerable<VentaDTO>>(VentaList);

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }

            return _response;
            
        }


        [HttpGet("{id:int}", Name = "GetVentasById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse<VentaDTO>>> GetVentasById(int id)
        {
            _logger.LogInformation($"Obteniendo datos de las Ventas por id: {id}");
            var _response = new APIResponse<VentaDTO>();

            /*try
            {
                if (id == 0)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }


                var Venta = await _VentaRepositorio.Obtener(p => p.Articulonro == id, tracked: false, incluirPropiedades: "TipoImpuesto,Marca,Presentacion,Categoria,UnidadMedida");

                if (Venta == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _mapper.Map<VentaDTO>(Venta);

               
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }*/
            return _response;

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse<VentaDTO>>> CrearVenta([FromBody] VentaCreateDTO CreateDTO)
        {
            var _response = new APIResponse<VentaDTO>();
            try
            {
                var existe = await _VentaRepositorio.Obtener(v => v.Establecimiento == CreateDTO.Establecimiento &&
                                                   v.PuntoExpedicion == CreateDTO.PuntoExpedicion &&
                                                   v.Numero == CreateDTO.Numero &&
                                                   v.TimbradoId == CreateDTO.TimbradoId &&
                                                   v.ClienteId == CreateDTO.ClienteId);
                if (existe != null)
                {
                    var mensajeError = "La numeración de la factura y timbrado ya existe para el mismo cliente";
                    ModelState.AddModelError("ErrorMessages", mensajeError);
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string>() { mensajeError };
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                //Parseo del DTO a la clase
                var _Venta = _mapper.Map<Venta>(CreateDTO);

                // Validar stock disponible para cada item
                foreach (var item in _Venta.DetalleVenta)
                {
                    var articulo = await _context.Articulo
                   .AsNoTracking()
                   .FirstOrDefaultAsync(a => a.ArticuloId == item.ItemId);

                    if (item.TipoItem == TipoArticulo.Servicio)
                        continue;


                    var disponible = await _stockRepositorio.ObtenerCantidadDisponibleAsync(item.ItemId, CreateDTO.UbicacionId);

                    if (disponible < item.Cantidad)
                    {
                        _response.isExitoso = false;
                        _response.ErrorMessages = new List<string>() { $"Stock insuficiente para el producto {articulo.Descripcion}({item.ItemId})" };
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        return BadRequest(_response);
                    }
                }

                // Crear venta (esto ahora maneja todo el proceso completo)
                var ventaCreada = await _VentaRepositorio.CreateVentaAsync(_Venta);


                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;
                _response.Resultado = _mapper.Map<VentaDTO>(ventaCreada);


                return CreatedAtRoute("GetVentasById", new { id = _Venta.Id }, _response);
            }
            catch (Exception ex)
            {   
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
            }
            return _response;

        }
    }
}
