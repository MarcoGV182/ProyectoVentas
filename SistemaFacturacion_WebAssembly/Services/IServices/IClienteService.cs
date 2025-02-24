using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IClienteService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(ClienteCreateDTO dto);
        Task<APIResponse> Actualizar<T>(int id, ClienteCreateDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
    }
}
