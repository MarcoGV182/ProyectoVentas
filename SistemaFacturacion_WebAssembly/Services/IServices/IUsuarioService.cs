using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_WebAssembly.Models;


namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IUsuarioService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> IniciarSesion<T>(UsuarioLogin login);
        Task<APIResponse> Crear<T>(UsuarioRegistroDTO dto);
        Task<APIResponse> Actualizar<T>(int id,UsuarioRegistroDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
    }
}
