using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;


namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ITimbradoService
    {
        Task<APIResponse> ObtenerTodos<T>();
        Task<APIResponse> Obtener<T>(int id);
        Task<APIResponse> Crear<T>(TimbradoCreateDTO dto);
        Task<APIResponse> Eliminar<T>(int id);
        Task<APIResponse> Actualizar<T>(int id, TimbradoCreateDTO dto);
    }
}
