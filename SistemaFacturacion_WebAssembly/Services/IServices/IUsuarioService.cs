using SistemaFacturacion_Model.Modelos.Custom;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IUsuarioService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<AutorizacionResponse> IniciarSesion(LoginDTO login);
        Task<APIResponse> Crear<T>(UsuarioRegistroDTO dto);
        Task<APIResponse> Actualizar<T>(int id, UsuarioRegistroDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
        Task<AutorizacionResponse> RefrescarToken(TokenRequest tokenRequest);
    }
}
