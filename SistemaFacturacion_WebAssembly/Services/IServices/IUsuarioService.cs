using SistemaFacturacion_Model.Modelos.Custom;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IUsuarioService
    {
        Task<APIResponse<T>> ObtenerTodos<T>();
        Task<AutorizacionResponse> IniciarSesion(LoginDTO login);
        Task<APIResponse<T>> Crear<T>(UsuarioRegistroDTO dto);
        Task<APIResponse<T>> Actualizar<T>(string id, UsuarioRegistroDTO dto);
        Task<APIResponse<T>> Eliminar<T>(string id);
        Task<AutorizacionResponse> RefrescarToken(TokenRequest tokenRequest);
    }
}
