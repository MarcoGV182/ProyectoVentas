using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Models.DTO;

namespace SistemaFacturacion_WebAssembly.Services.IServices 
{ 
    public interface IProductoService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(ProductoCreateDTO dto);
        Task<APIResponse> Actualizar<T>(ProductoUpdateDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
    }
}
