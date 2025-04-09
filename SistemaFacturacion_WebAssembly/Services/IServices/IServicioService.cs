using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices 
{ 
    public interface IServicioService
    {
        Task<APIResponse<List<ServicioDTO>>> ObtenerTodos();
        Task<APIResponse<ServicioDTO>> Obtener(int id);
        Task<APIResponse<ServicioDTO>> Crear(ServicioCreateDTO dto);
        Task<APIResponse<object>> Actualizar(int id, ServicioCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
    }
}
