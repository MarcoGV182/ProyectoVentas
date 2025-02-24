using Newtonsoft.Json.Linq;
using SistemaFacturacion_Model.Modelos.DTOs;

namespace SistemaFacturacion_WebAssembly.Services
{
    public class UsuarioEstadoService
    {
        private UsuarioResponse _currentUser;
        private string _token;

        public UsuarioResponse CurrentUser
        {
            get => _currentUser;
            private set
            {
                _currentUser = value;
                NotifyStateChanged();
            }
        }

        public string Token
        {
            get => _token;
            private set
            {
                _token = value;
                NotifyStateChanged();
            }
        }

        public event Action OnChange;

        public void SetCurrentUser(UsuarioResponse user)
        {
            CurrentUser = user;
        }

        public void SetToken(string token)
        {
            Token = token;
        }

        public void ClearState()
        {
            CurrentUser = null;
            Token = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
