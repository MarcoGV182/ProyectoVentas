using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace SistemaFacturacion_WebAssembly.Models
{
    public class AuthTokenHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorageService;

        public AuthTokenHandler(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Obtiene el token desde el almacenamiento local
            var accessToken = await _localStorageService.GetItemAsync<string>("accessToken");

            if (!string.IsNullOrEmpty(accessToken))
            {
                // Agrega el token al encabezado Authorization
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            // Continúa la solicitud
            return await base.SendAsync(request, cancellationToken);
        }
    }

}
