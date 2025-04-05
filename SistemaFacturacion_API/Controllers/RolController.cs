using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaFacturacion_API.Datos;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using System.Net;

namespace SistemaFacturacion_API.Controllers
{
    //[Authorize(Roles = "Admin")] // Solo usuarios con rol "Admin" pueden acceder
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Usuario> _userManager;

        public RolController(RoleManager<IdentityRole> roleManager, UserManager<Usuario> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpPost("crear")]
        public async Task<ActionResult<APIResponse<IdentityRole>>> CrearRol([FromBody] string nombreRol)
        {
            var _apiResponse = new APIResponse<IdentityRole>();
            _apiResponse.isExitoso = true;
            _apiResponse.StatusCode = HttpStatusCode.OK;
            try
            {
                if (string.IsNullOrEmpty(nombreRol))
                {
                    _apiResponse.isExitoso = false;
                    _apiResponse.ErrorMessages = new List<string> { "El nombre del rol es requerido." };
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;

                    return BadRequest(_apiResponse);
                }

                var rolExiste = await _roleManager.RoleExistsAsync(nombreRol);
                if (rolExiste)
                {
                    _apiResponse.isExitoso = false;
                    _apiResponse.ErrorMessages = new List<string> { "El rol ya existe." };
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;

                    return BadRequest(_apiResponse);
                }

                var identityRole = new IdentityRole(nombreRol);
                var resultado = await _roleManager.CreateAsync(identityRole);
                if (resultado.Succeeded)
                {
                    _apiResponse.Resultado = identityRole;
                    return Ok(_apiResponse);
                }

            }
            catch (Exception ex)
            {
                _apiResponse.isExitoso = false;
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.ErrorMessages = new List<string>() { ex.Message.ToString() };
            }

            return _apiResponse;
        }



        [HttpGet("listar")]
        public async Task<ActionResult<APIResponse<IEnumerable<IdentityRole>>>> ListarRoles()
        {
            var _apiResponse = new APIResponse<IEnumerable<IdentityRole>>();
            try
            {
                var roles = await _roleManager.Roles.ToListAsync();
                _apiResponse.isExitoso = true;
                _apiResponse.Resultado = roles;
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.isExitoso = false;
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.ErrorMessages = new List<string>() { ex.Message.ToString() };
                return BadRequest(_apiResponse);
            }

            
        }


        [HttpPost("asignar-rol")]
        public async Task<ActionResult<APIResponse<object>>> AsignarRol([FromBody] RolAsignarDTO model)
        {
            var _apiResponse = new APIResponse<object>();
            _apiResponse.isExitoso = true;
            _apiResponse.StatusCode = HttpStatusCode.OK;
            try
            {
                #region Validaciones
                if (string.IsNullOrEmpty(model.UsuarioId))
                {
                    _apiResponse.isExitoso = false;
                    _apiResponse.ErrorMessages = new List<string> { "El Usuario es requerido." };
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;

                    return BadRequest(_apiResponse);
                }

                if (string.IsNullOrEmpty(model.NombreRol))
                {
                    _apiResponse.isExitoso = false;
                    _apiResponse.ErrorMessages = new List<string> { "El Rol es requerido." };
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;

                    return BadRequest(_apiResponse);
                }

                var rolExiste = await _roleManager.FindByNameAsync(model.NombreRol);
                if (rolExiste == null)
                {
                    _apiResponse.isExitoso = false;
                    _apiResponse.ErrorMessages = new List<string> { "El Rol a asignar no existe" };
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;

                    return BadRequest(_apiResponse);
                }

                var usuarioExiste = await _userManager.FindByIdAsync(model.UsuarioId);
                if (usuarioExiste == null)
                {
                    _apiResponse.isExitoso = false;
                    _apiResponse.ErrorMessages = new List<string> { "El Rol a asignar no existe" };
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;

                    return BadRequest(_apiResponse);
                }
                #endregion

                var resultado = await _userManager.AddToRoleAsync(usuarioExiste, model.NombreRol);
                if (resultado.Succeeded)
                {
                    _apiResponse.isExitoso = true;
                    _apiResponse.StatusCode = HttpStatusCode.OK;
                    _apiResponse.Resultado = null;
                }

            }
            catch (Exception ex)
            {
                _apiResponse.isExitoso = false;
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                _apiResponse.ErrorMessages = new List<string>() { ex.Message.ToString() };
            }

            return Ok(_apiResponse);
        }

    }
}
