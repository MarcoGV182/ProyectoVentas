using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;


namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ISucursalService
    {
        Task<APIResponse<List<SucursalDTO>>> ObtenerTodos();
        Task<APIResponse<SucursalDTO>> Obtener(int id);
        Task<APIResponse<SucursalDTO>> Crear(SucursalCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
        Task<APIResponse<object>> Actualizar(int id, SucursalCreateDTO dto);
    }   
}
