using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ICategoriaService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(CategoriaProductoCreateDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
        Task<APIResponse> Actualizar<T>(int id, CategoriaProductoCreateDTO dto);
    }
}
