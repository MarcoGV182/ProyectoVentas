using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices 
{ 
    public interface IServicioService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(ServicioCreateDTO dto);
        Task<APIResponse> Actualizar<T>(int id, ServicioCreateDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
    }
}
