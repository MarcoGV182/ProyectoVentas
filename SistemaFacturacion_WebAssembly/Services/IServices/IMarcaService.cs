using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_WebAssembly.Models;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IMarcaService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(MarcaCreateDTO dto);
        Task<APIResponse> Actualizar<T>(int id, MarcaCreateDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
    }
}
