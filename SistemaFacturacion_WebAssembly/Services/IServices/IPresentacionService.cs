using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface IPresentacionService
    {
        Task<APIResponse<List<PresentacionDTO>>> ObtenerTodos();
        Task<APIResponse<PresentacionDTO>> Obtener(int id);
        Task<APIResponse<PresentacionDTO>> Crear(PresentacionCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
        Task<APIResponse<object>> Actualizar(int id, PresentacionCreateDTO dto);
    }
}
