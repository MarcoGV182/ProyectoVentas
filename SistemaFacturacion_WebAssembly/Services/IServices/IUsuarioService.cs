using SistemaFacturacion_Model.Modelos.Custom;
using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;
using SistemaFacturacion_WebAssembly.Models;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IUsuarioService
    {
        Task<APIResponse<List<UsuarioDTO>>> ObtenerTodos();
        Task<APIResponse<AutorizacionResponse>> IniciarSesion(LoginDTO login);
        Task<APIResponse<UsuarioDTO>> Crear(UsuarioRegistroDTO dto);
        Task<APIResponse<object>> Actualizar(string id, UsuarioRegistroDTO dto);
        Task<APIResponse<object>> Eliminar(string id);
        Task<APIResponse<AutorizacionResponse>> RefrescarToken(TokenRequest tokenRequest);
    }
}
