using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices 
{ 
    public interface IProductoService
    {
        Task<APIResponse<T>> ObtenerTodos<T>();
        Task<APIResponse<T>> Obtener<T>(int id);
        Task<APIResponse<T>> Crear<T>(ProductoCreateDTO dto);
        Task<APIResponse<T>> Actualizar<T>(int id, ProductoUpdateDTO dto);
        Task<APIResponse<T>> Eliminar<T>(int id);
        Task<APIResponse<T>> ObtenerStock<T>(int idProducto,int ubicacion);
    }
}
