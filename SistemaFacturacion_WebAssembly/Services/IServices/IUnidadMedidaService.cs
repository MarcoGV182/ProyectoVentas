using SistemaFacturacion_WebAssembly.Models;
using SistemaFacturacion_WebAssembly.Models.DTO;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IUnidadMedidaService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(TablaMenorDTO dto);
        Task<APIResponse> Actualizar<T>(int id, TablaMenorDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
    }
}
