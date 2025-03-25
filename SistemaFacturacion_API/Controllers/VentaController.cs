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
        protected APIResponse _response;

        public VentaController(ILogger<VentaController> logger, IVentaRepositorio ventaRepositorio, IMapper mapper)
        {
            _logger = logger;
            _VentaRepositorio = ventaRepositorio;
            _mapper = mapper;
            _response = new APIResponse();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVentas()
        {
            //_logger.LogInformation("Obteniendo datos de las Ventas");
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
        public async Task<ActionResult<APIResponse>> GetVentasById(int id)
        {
            _logger.LogInformation($"Obteniendo datos de las Ventas por id: {id}");

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
        public async Task<ActionResult<APIResponse>> CrearVenta([FromBody] VentaCreateDTO CreateDTO)
        {
            try
            {
                var existe = _VentaRepositorio.Obtener(v => v.Establecimiento == CreateDTO.Establecimiento &&
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

                await _VentaRepositorio.CreateVentaAsync(_Venta);

                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _Venta;


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
