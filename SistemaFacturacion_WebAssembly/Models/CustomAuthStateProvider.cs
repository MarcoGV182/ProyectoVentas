using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_WebAssembly.Services;

namespace SistemaFacturacion_WebAssembly.Models
{
    public class CustomAuthStateProvider: AuthenticationStateProvider
    {
        private readonly AuthenticationState _anonymous;
        private readonly UsuarioEstadoService _usuarioEstadoService;

        public CustomAuthStateProvider(UsuarioEstadoService usuarioEstadoService)
        {
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            _usuarioEstadoService = usuarioEstadoService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await _usuarioEstadoService.LoadStateAsync();
            var token = _usuarioEstadoService.Token;

            if (string.IsNullOrEmpty(token))
            {
                return _anonymous;
            }

            var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "Bearer");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }

        public async Task MarkUserAsAuthenticatedAsync(string token, UsuarioResponse user)
        {
            await _usuarioEstadoService.SetTokenAsync(token);
            await _usuarioEstadoService.SetCurrentUserAsync(user);

            var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "Bearer");
            var userPrincipal = new ClaimsPrincipal(identity);

            var authState = new AuthenticationState(userPrincipal);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public async Task MarkUserAsLoggedOutAsync()
        {
            await _usuarioEstadoService.ClearStateAsync();
            var authState = _anonymous;
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
    }
}
