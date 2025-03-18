using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IUnidadMedidaService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(UnidadMedidaCreateDTO dto);
        Task<APIResponse> Actualizar<T>(int id, UnidadMedidaCreateDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
    }
}
