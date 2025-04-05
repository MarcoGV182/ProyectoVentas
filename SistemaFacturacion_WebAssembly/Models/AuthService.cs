using Blazored.LocalStorage;
using SistemaFacturacion_Model.Modelos.DTOs;

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
            await _authStateProvider.MarkUserAsAuthenticatedAsync(token, user);
        }

        public async Task LogoutAsync()
        {
            await _authStateProvider.MarkUserAsLoggedOutAsync();
        }
    }
}
