using Blazored.LocalStorage;
using Newtonsoft.Json.Linq;
using SistemaFacturacion_Model.Modelos.DTOs;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class UsuarioEstadoService
    {
        private readonly ILocalStorageService _localStorageService;
        private const string UserKey = "Usuario";
        private const string TokenKey = "accessToken";

        public UsuarioResponse CurrentUser { get; private set; }
        public string Token { get; private set; }

        public UsuarioEstadoService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }


        public async Task SetCurrentUserAsync(UsuarioResponse user)
        {
            CurrentUser = user;
            await _localStorageService.SetItemAsync(UserKey, user);
            NotifyStateChanged();
        }

        public async Task SetTokenAsync(string token)
        {
            Token = token;
            await _localStorageService.SetItemAsync(TokenKey, token);
            NotifyStateChanged();
        }

        public async Task LoadStateAsync()
        {
            CurrentUser = await _localStorageService.GetItemAsync<UsuarioResponse>(UserKey);
            Token = await _localStorageService.GetItemAsync<string>(TokenKey);
            NotifyStateChanged();
        }

        public async Task ClearStateAsync()
        {
            CurrentUser = null;
            Token = null;
            await _localStorageService.RemoveItemAsync(UserKey);
            await _localStorageService.RemoveItemAsync(TokenKey);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => StateChanged?.Invoke();
        public event Action StateChanged;
    }
}
