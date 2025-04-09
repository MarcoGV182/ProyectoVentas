using SistemaFacturacion_Model.Modelos.DTOs;
using SistemaFacturacion_Utilidad;

namespace SistemaFacturacion_WebAssembly.Services.IServices
{
    public interface ICiudadService
    {
        Task<APIResponse<List<CiudadDTO>>> ObtenerTodos();
        Task<APIResponse<CiudadDTO>> Obtener(int id);
        Task<APIResponse<CiudadDTO>> Crear(CiudadCreateDTO dto);
        Task<APIResponse<object>> Actualizar(int id, CiudadCreateDTO dto);
        Task<APIResponse<object>> Eliminar(int id);
    }
}
