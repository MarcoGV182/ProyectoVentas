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
using SistemaFacturacion_API.Services;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private readonly ILogger<VentaController> _logger;
        private readonly IMapper _mapper;
        private readonly VentaService _ventaService;
        private readonly ApplicationDbContext _context;

        public VentaController(ILogger<VentaController> logger, IMapper mapper, ApplicationDbContext context, VentaService ventaService)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _ventaService = ventaService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse<IEnumerable<VentaDTO>>>> GetVentas()
        {
            //_logger.LogInformation("Obteniendo datos de las Ventas");
            var _response = new APIResponse<IEnumerable<VentaDTO>>();
            try
            {                
                var VentaList = await _ventaService.GetVentas();
                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _mapper.Map<IEnumerable<VentaDTO>>(VentaList);                
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };

                return BadRequest(_response);
            }

            return Ok(_response);
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
                if (CreateDTO == null)
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var ventaRegistrada = await _ventaService.RegistrarVenta(CreateDTO);            

                
                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.Created;
                _response.Resultado = ventaRegistrada;


                return CreatedAtRoute("GetVentasById", new { Id = ventaRegistrada.Id }, _response);
            }
            catch (Exception ex)
            {   
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message };
                return BadRequest(_response);
            }
        

        }
    }
}
