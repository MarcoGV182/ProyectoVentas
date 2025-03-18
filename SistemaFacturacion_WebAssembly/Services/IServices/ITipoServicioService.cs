using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ITipoServicioService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(TablaMenorCreateDTO dto);
        Task<APIResponse> Actualizar<T>(int id, TablaMenorCreateDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
    }
}
