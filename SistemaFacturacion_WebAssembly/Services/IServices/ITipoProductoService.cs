using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Models.DTO;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ITipoProductoService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(TipoProductoCreateDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
        Task<APIResponse> Actualizar<T>(int id, TipoProductoCreateDTO dto);
    }
}
