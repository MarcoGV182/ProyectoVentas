using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_API.Modelos;
using SistemaFacturacion_API.Modelos.DTO;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using System.Net;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoImpuestoController : ControllerBase
    {
        private readonly ILogger<TipoImpuestoController> _logger;
        private readonly IMapper _mapper;
        private readonly ITipoImpuestoRepositorio _tipoImpuestoRepositorio;
        protected APIResponse _response;

        public TipoImpuestoController(ILogger<TipoImpuestoController> logger, IMapper mapper, ITipoImpuestoRepositorio TIRepositorio)
        {
            _logger = logger;
            _mapper = mapper;
            _tipoImpuestoRepositorio = TIRepositorio;
            _response = new APIResponse();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> ObtenerTipoImpuesto()
        {
            try
            {
                //_logger.LogInformation("Obteniendo lista de Marcas");
                IEnumerable<TipoImpuesto> TipoImpuestoList = await _tipoImpuestoRepositorio.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<TipoImpuestoDTO>>(TipoImpuestoList);
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
    }
}
