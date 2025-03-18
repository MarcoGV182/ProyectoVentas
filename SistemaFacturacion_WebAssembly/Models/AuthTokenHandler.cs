using Blazored.LocalStorage;
using SistemaFacturacion_WebAssembly.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;

namespace SistemaFacturacion_WebAssembly.Models
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorageService;
        private readonly UsuarioEstadoService _userStateService;

        // Lista de endpoints públicos
        private readonly HashSet<string> _publicEndpoints = new HashSet<string>
        {
            "/api/Usuario/IniciarSesion", // Endpoint público
        };

        public AuthTokenHandler(ILocalStorageService localStorageService, UsuarioEstadoService userStateService)
        {
            _localStorageService = localStorageService;
            _userStateService = userStateService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Verifica si la solicitud es para un endpoint público
            var requestUri = request.RequestUri?.AbsolutePath;
            var isPublicEndpoint = requestUri != null && _publicEndpoints.Contains(requestUri);


            if (!isPublicEndpoint)
            {
                var accessToken = _userStateService.Token ?? await _localStorageService.GetItemAsync<string>("accessToken");

                if (!string.IsNullOrEmpty(accessToken))
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.ReadJwtToken(accessToken);

                    if (token.ValidTo < DateTime.UtcNow) // Token expirado
                    {
                        await _localStorageService.RemoveItemAsync("accessToken");
                        throw new UnauthorizedAccessException("El token ha expirado.");
                    }

                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }
                        

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                await _localStorageService.RemoveItemAsync("accessToken");
                throw new UnauthorizedAccessException("Acceso no autorizado.");
            }

            return response;
        }
    }

}
