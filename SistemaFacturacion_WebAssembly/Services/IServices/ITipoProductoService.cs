using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ICategoriaService
    {
        Task<APIResponse<List<CategoriaProductoDTO>>> ObtenerTodos();
        Task<APIResponse<CategoriaProductoDTO>> Obtener(int id);
        Task<APIResponse<CategoriaProductoDTO>> Crear(CategoriaProductoCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
        Task<APIResponse<object>> Actualizar(int id, CategoriaProductoCreateDTO dto);
    }
}
