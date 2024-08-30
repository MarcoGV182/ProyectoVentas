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
using System.Net;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAutorizacionService _autorizacionService;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public UsuarioController(IAutorizacionService autorizacionService, IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _autorizacionService = autorizacionService;
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("Autenticar")]
        public async Task<ActionResult<APIResponse>> Autenticar([FromBody] AutorizacionRequest autorizacion) 
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
        public async Task<ActionResult<APIResponse>> GetUsuario()
        {
            //_logger.LogInformation("Obteniendo datos del Usuario");

            try 
            {
                IEnumerable<Usuario> UsuarioList = await _usuarioRepositorio.ObtenerTodos();

                if (UsuarioList == null)
                {
                    return NoContent();
                }

                _response.Resultado = _mapper.Map<IEnumerable<UsuarioDTO>>(UsuarioList);
                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest(_response);
            }
           
        }


        [HttpGet("id:int", Name = "GetUsuarioById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> GetUsuarioById(int id)
        {
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            try
            {
                if (id == 0)
                    return BadRequest();

                var UsuarioResult = await _usuarioRepositorio.Obtener(p => p.UsuarioId == id, incluirPropiedades: "Colaborador");               

                if (UsuarioResult == null)
                    return NoContent();

                _response.Resultado = _mapper.Map<IEnumerable<UsuarioDTO>>(UsuarioResult);
                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest(_response);
            }

        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> RegistrarUsuario([FromBody] UsuarioCreateDTO CreateDTO)
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
                _UsuarioNuevo.Fechaalta = DateTime.Now;
                _UsuarioNuevo.Estado = "A";

                await _usuarioRepositorio.Crear(_UsuarioNuevo);

                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _UsuarioNuevo;

                return CreatedAtRoute("GetUsuarioById", new { id = _UsuarioNuevo.UsuarioId }, _response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest(_response);
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

            var autorizacionResponse = await _autorizacionService.DevolverRefrestToken(resquest, short.Parse(idUsuarioJwt));

            if (autorizacionResponse.Resultado)
            {
                return Ok(autorizacionResponse);
            }
            else
            {
                return BadRequest(autorizacionResponse);
            }
        }


        [HttpPost]
        [Route("IniciarSesion")]
        public async Task<ActionResult<APIResponse>> IniciarSesion([FromBody] LoginDTO loginDto)
        {
            APIResponse _response = new APIResponse();
            try
            {
                Usuario _usuario = await _usuarioRepositorio.Obtener(u => u.Login == loginDto.Usuario, incluirPropiedades: "Colaborador");

                if (_usuario == null)
                {
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string>() { "El Usuario/Login no existe" };
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;
                }

                if (!BCrypt.Net.BCrypt.Verify(loginDto.Clave, _usuario.Password))
                {
                    _response.isExitoso = false;
                    _response.ErrorMessages = new List<string>() { "La contraseña ingresada es incorrecta"};
                    _response.StatusCode = HttpStatusCode.NoContent;
                    return _response;

                }

                _response.isExitoso = true;
                _response.Resultado = _usuario;
                _response.StatusCode = HttpStatusCode.OK;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.ErrorMessages = new List<string>() { ex.Message.ToString() };
                return _response;
            }        
        }
    }
}
