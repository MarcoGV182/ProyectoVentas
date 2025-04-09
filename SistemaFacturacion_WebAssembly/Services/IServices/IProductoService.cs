using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices 
{ 
    public interface IProductoService
    {
        Task<APIResponse<List<ProductoDTO>>> ObtenerTodos();
        Task<APIResponse<ProductoDTO>> Obtener(int id);
        Task<APIResponse<ProductoDTO>> Crear(ProductoCreateDTO dto);
        Task<APIResponse<object>> Actualizar(int id, ProductoUpdateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
        Task<APIResponse<StockDTO>> ObtenerStock(int idProducto,int ubicacion);
    }
}
