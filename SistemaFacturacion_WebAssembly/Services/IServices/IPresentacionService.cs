using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IPresentacionService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(PresentacionCreateDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
        Task<APIResponse> Actualizar<T>(int id, PresentacionCreateDTO dto);
    }
}
