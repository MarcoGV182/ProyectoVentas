using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IUnidadMedidaService
    {
        Task<APIResponse<List<UnidadMedidaDTO>>> ObtenerTodos();
        Task<APIResponse<UnidadMedidaDTO>> Obtener(int id);
        Task<APIResponse<UnidadMedidaDTO>> Crear(UnidadMedidaCreateDTO dto);
        Task<APIResponse<object>> Actualizar(int id, UnidadMedidaCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
    }
}
