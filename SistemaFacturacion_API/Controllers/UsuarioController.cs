using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_API.Modelos;
using SistemaFacturacion_API.Modelos.Custom;
using SistemaFacturacion_API.Modelos.DTO;
using SistemaFacturacion_API.Recursos;
using SistemaFacturacion_API.Repositorio;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_API.Services;
using System.IdentityModel.Tokens.Jwt;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAutorizacionService _autorizacionService;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioController(IAutorizacionService autorizacionService, IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _autorizacionService = autorizacionService;
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar([FromBody] AutorizacionRequest autorizacion) 
        {
            var resultado_autorizacion = await _autorizacionService.DevolverToken(autorizacion);

            if (resultado_autorizacion == null)
            {
                return Unauthorized();
            }

            return Ok(resultado_autorizacion);
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuario()
        {
            //_logger.LogInformation("Obteniendo datos de las Productos");


            IEnumerable<Usuario> UsuarioList = await _usuarioRepositorio.ObtenerTodos();

            return Ok(_mapper.Map<IEnumerable<UsuarioDTO>>(UsuarioList));
        }


        [HttpGet("id:int", Name = "GetUsuarioById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuarioById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            try
            {
                if (id == 0)
                    return BadRequest();

                var UsuarioResult = await _usuarioRepositorio.Obtener(p => p.UsuarioId == id, incluirPropiedades: "Colaborador");

                if (UsuarioResult == null)
                    return NoContent();

                return Ok(UsuarioResult);
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
        public async Task<ActionResult<Usuario>> RegistrarUsuario([FromBody] UsuarioCreateDTO CreateDTO)
        {
            try
            {
                if (!await _usuarioRepositorio.ValidarUsuario(CreateDTO))
                {
                    ModelState.AddModelError("Validaciones", "El registro para el nuevo usuario no cumple con las condiciones.");
                    return BadRequest(ModelState);
                }

                if (CreateDTO == null)
                {
                    return BadRequest();
                }

                var _UsuarioNuevo = _mapper.Map<Usuario>(CreateDTO);

                _UsuarioNuevo.Password = Utilidades.EncriptarClave(CreateDTO.Password);

                await _usuarioRepositorio.Crear(_UsuarioNuevo);

                return CreatedAtRoute("GetUsuarioById", new { id = _UsuarioNuevo.UsuarioId }, _UsuarioNuevo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }



        [HttpPost]
        [Route("ObtenerRefreshToken")]
        public async Task<IActionResult> ObtenerRefreshToken([FromBody] RefreshTokenRequest resquest)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenExpirado = tokenHandler.ReadJwtToken(resquest.TokenExpirado);

            if (tokenExpirado.ValidTo > DateTime.UtcNow)
            {
                return BadRequest(new AutorizacionResponse() 
                { 
                    Resultado = false,
                    Mensaje = "Token aun no ha expirado"
                });
            }

            string idUsuarioJwt = tokenExpirado.Claims.First(x =>
            x.Type == JwtRegisteredClaimNames.NameId).Value.ToString();

            var autorizacionResponse = await _autorizacionService.DevolverRefrestToken(resquest, int.Parse(idUsuarioJwt));

            if (autorizacionResponse.Resultado)
            {
                return Ok(autorizacionResponse);
            }
            else
            {
                return BadRequest(autorizacionResponse);
            }
        }
    }
}
