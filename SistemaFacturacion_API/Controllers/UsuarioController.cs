using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos;
using SistemaFacturacion_Model.Modelos.Custom;
using SistemaFacturacion_API.Recursos;
using SistemaFacturacion_API.Repositorio;
using SistemaFacturacion_API.Repositorio.IRepositorio;
using SistemaFacturacion_API.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SistemaFacturacion_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IAutorizacionService _autorizacionService;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public UsuarioController(IAutorizacionService autorizacionService, IUsuarioRepositorio usuarioRepositorio, IMapper mapper, UserManager<IdentityUser> userManager = null)
        {
            _autorizacionService = autorizacionService;
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetUsuario()
        {
            //_logger.LogInformation("Obteniendo datos del Usuario");
            _response = new APIResponse();
            try 
            {
                IEnumerable<IdentityUser> UsuarioList = await _usuarioRepositorio.ObtenerTodos();

                if (UsuarioList == null)
                {
                    return NoContent();
                }

                _response.Resultado = UsuarioList;
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


        [HttpGet("id:string", Name = "GetUsuarioById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> GetUsuarioById(string id)
        {
            _response = new APIResponse();
            //_logger.LogInformation($"Obteniendo datos de las Productos por id: {id}");
            try
            {
                if (string.IsNullOrEmpty(id))
                    return BadRequest();

                var UsuarioResult = await _userManager.FindByIdAsync(id);               

                if (UsuarioResult == null)
                    return NoContent();

                _response.Resultado = UsuarioResult;
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
        [Route("Registrar")]
        public async Task<ActionResult<APIResponse>> RegistrarUsuario([FromBody] UsuarioRegistroDTO CreateDTO)
        {
               _response = new APIResponse();
            try
            {
                //Validar el estado del modelo
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                //Validar que el objeto no se nulo
                if (CreateDTO == null)
                {
                    return BadRequest();
                }
                //Verificar que el Email ingresado exista
                var emailExists = await _userManager.FindByEmailAsync(CreateDTO.DireccionEmail);
                if (emailExists != null) 
                {
                    _response.isExitoso = false;
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.ErrorMessages = new List<string>() { "El email ingresado ya existe" };
                    _response.Resultado = null;
                    return BadRequest(_response);
                }


                //Validar datos del usuario
                if (!await _usuarioRepositorio.ValidarUsuario(CreateDTO))
                {
                    ModelState.AddModelError("Validaciones", "El registro para el nuevo usuario no cumple con las condiciones.");
                    return BadRequest(ModelState);
                }

                //Mapear objecto recibido por parametro
                IdentityUser _UsuarioNuevo = new IdentityUser();
                _UsuarioNuevo.Email = CreateDTO.DireccionEmail;
                _UsuarioNuevo.UserName = CreateDTO.UserName;

                var isCreated = await _userManager.CreateAsync(_UsuarioNuevo, CreateDTO.Password);
                if (!isCreated.Succeeded)
                {
                    var listaErrores = isCreated.Errors.Select(c => c.Description).ToList();
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    _response.isExitoso = false;
                    _response.ErrorMessages = listaErrores;
                    return BadRequest(_response);
                }


                _response.isExitoso = true;
                _response.StatusCode = HttpStatusCode.OK;
                _response.Resultado = _UsuarioNuevo;

                return CreatedAtRoute("GetUsuarioById", new { id = _UsuarioNuevo.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.isExitoso = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return BadRequest(_response);
            }

        }
       

        [HttpPost]
        [Route("IniciarSesion")]
        public async Task<ActionResult<AutorizacionResponse>> IniciarSesion([FromBody] LoginDTO loginDto)
        {
            AutorizacionResponse _response = new AutorizacionResponse();
            try
            {
                #region Validaciones
                //Validar el estado del modelo
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                //Verificar que el Email ingresado exista
                var existingUser = await _userManager.FindByEmailAsync(loginDto.DireccionEmail);
                if (existingUser == null)
                {
                    _response.Resultado = false;
                    _response.Mensaje = new List<string>() { "El Usuario/Email no existe" };
                    return BadRequest(_response);
                }

                //Validar credenciales
                var checkUserAndPass = await _userManager.CheckPasswordAsync(existingUser, loginDto.Password);
                if (!checkUserAndPass)
                {
                    _response.Resultado = false;
                    _response.Mensaje = new List<string>() { "Credenciales Inválidas" };
                    return BadRequest(_response);
                }
                #endregion

                //Se genera el token para devolver al usuario
                var resultToken = _autorizacionService.GenerarToken(existingUser);
                _response.Token = resultToken;
                _response.Resultado = true;

                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.Resultado = false;
                _response.Mensaje = new List<string>() { ex.Message.ToString() };
                return BadRequest(_response);
            }        
        }
    }
}
