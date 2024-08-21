using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Models.DTO;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ITipoImpuestoService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(TipoImpuestoCreateDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
        Task<APIResponse> Actualizar<T>(int id,TipoImpuestoCreateDTO dto);
    }
}
