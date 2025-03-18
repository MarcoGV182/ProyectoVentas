using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace SistemaFacturacion_WebAssembly.Models
{
    public class CustomAuthStateProvider: AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly AuthenticationState _anonymous;

        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorageService = localStorage;
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorageService.GetItemAsync<string>("accessToken");

            if (string.IsNullOrEmpty(token))
            {
                return _anonymous;
            }

            var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "Bearer");
            var user = new ClaimsPrincipal(identity);

            return new AuthenticationState(user);
        }

        public void MarkUserAsAuthenticated(string token)
        {
            var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "Bearer");
            var user = new ClaimsPrincipal(identity);

            var authState = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public void MarkUserAsLoggedOut()
        {
            var authState = _anonymous;
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }
    }
}
