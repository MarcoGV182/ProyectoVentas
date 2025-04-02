using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ICategoriaService
    {
        Task<APIResponse<T>> ObtenerTodos<T>();
        Task<APIResponse<T>> Obtener<T>(int id);
        Task<APIResponse<T>> Crear<T>(CategoriaProductoCreateDTO dto);
        Task<APIResponse<T>> Eliminar<T>(int id);
        Task<APIResponse<T>> Actualizar<T>(int id, CategoriaProductoCreateDTO dto);
    }
}
