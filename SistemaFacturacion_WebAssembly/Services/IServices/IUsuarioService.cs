using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Models.DTO;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IUsuarioService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> IniciarSesion<T>(UsuarioLogin login);
        Task<APIResponse> Crear<T>(UsuarioCreateDTO dto);
        Task<APIResponse> Actualizar<T>(UsuarioDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
    }
}
