using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ICiudadService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(CiudadCreateDTO dto);
        Task<APIResponse> Actualizar<T>(int id, CiudadDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
    }
}
