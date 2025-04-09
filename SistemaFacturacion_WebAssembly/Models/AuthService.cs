using Blazored.LocalStorage;
using SistemaFacturacion_Model.Modelos.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SistemaFacturacion_WebAssembly.Models
{
    public class AuthService
    {
        private readonly CustomAuthStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorageService;

        public AuthService(CustomAuthStateProvider authStateProvider, ILocalStorageService localStorageService)
        {
            _authStateProvider = authStateProvider;
            _localStorageService = localStorageService;
        }

        public async Task LoginAsync(string token, UsuarioResponse user)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var roleClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role || c.Type == "role")?.Value;
            var sucursalClaim = jwtToken.Claims.FirstOrDefault(c=> c.Type == "SucursalId")?.Value;
            user.Rol = roleClaim;
            user.SucursalId = string.IsNullOrEmpty(sucursalClaim) ? 0 : Convert.ToInt32(sucursalClaim);

            await _authStateProvider.MarkUserAsAuthenticatedAsync(token, user);
        }

        public async Task LogoutAsync()
        {
            await _authStateProvider.MarkUserAsLoggedOutAsync();
        }
    }
}
